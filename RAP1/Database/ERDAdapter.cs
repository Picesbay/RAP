﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

using RAP.Entity;

namespace RAP.Database
{
    abstract class ERDAdapter
    {
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        //Part of step 2.3.3 in Week 8 tutorial. This method is a gift to you because .NET's approach to converting strings to enums is so horribly broken
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Creates and returns (but does not open) the connection to the database.
        /// </summary>
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static List<Researcher> fetchBasicResearcherDetails()
        {
            List<Researcher> res = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, level from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.

                    res.Add(new Researcher
                    {
                        ID = rdr.GetInt32(0),
                        GivenName = rdr.GetString(1),
                        FamilyName = rdr.GetString(2),
                        Title = rdr.GetString(3),
                        position = new Position { Level = rdr.IsDBNull(4) ? EmploymentLevel.Student : ParseEnum<EmploymentLevel>(rdr.GetString(4)) }
                    }); ;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return res;
        }

        public static Researcher fetchFullResearcherDetails(int id)
        {
            List<Researcher> researchers = fetchBasicResearcherDetails();
            Researcher res = (from r in researchers
                              where r.ID == id
                              select r).SingleOrDefault();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select unit, campus, email, " +
                                                    "photo from researcher where id = " + id, conn);
               //cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    res.Unit = rdr.GetString(0);
                    res.Campus = rdr.GetString(1);
                    res.Email = rdr.GetString(2);
                    res.Photo = rdr.GetString(3);

                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return res;
        }

        public static Researcher completeResearcherDetails(Researcher r)
        {
            r = fetchFullResearcherDetails(r.ID);
            r.publications = ERDAdapter.fetchBasicPublicationDetails(r);


            string query = @"select researcher.id, 
                                    if (researcher.level is NULL, researcher.type, researcher.level) level, 
                                    if (position.start is NULL, researcher.utas_start, position.start) start, end 
                            from researcher left join position on researcher.id = position.id 
                            where researcher.id = ";

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query + r.ID, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    r.positions.Add(new Position
                    {
                        Level = ParseEnum<EmploymentLevel>(rdr.GetString(1)),
                        Start = rdr.GetDateTime(2),
                        End = rdr.IsDBNull(3) ? default(DateTime) : rdr.GetDateTime(3)
                    });
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return r;
        }
        public static List<Publication> fetchBasicPublicationDetails(Researcher r)
        {
            List<Publication> pub = new List<Publication>();

            string query = @"select researcher_publication.doi, publication.year, publication.title 
                             from researcher_publication
                             left join publication
                             on researcher_publication.doi = publication.doi
                             where researcher_id = ";

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query + r.ID, conn);
                //cmd.Parameters.AddWithValue("researcher_id", r.ID);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    pub.Add(new Publication { DOI = rdr.GetString(0), Year = rdr.GetInt32(1), Title = rdr.GetString(2) });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return pub;
        }
        public static Publication completePublicationDetails(Publication pub)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            string query = @"select authors, type, cite_as, available, doi from publication where doi = '" + pub.DOI + "'";
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("doi", pub.DOI.ToString());
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    pub.Authors = rdr.GetString(0);
                    pub.Type = ParseEnum<OutputType>(rdr.GetString(1));
                    pub.CiteAs = rdr.GetString(2);
                    pub.Available = rdr.GetDateTime(3);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return pub;
        }


        public static List<Student> fetchStudentsDetails()
        {
            List<Student> students = new List<Student>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, supervisor_id, degree from researcher where type = 'Student'", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    students.Add(new Student { ID = rdr.GetInt32(0), SupervisorID = rdr.GetInt32(1), Degree = rdr.GetString(2) });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return students;
        }
    }
}
