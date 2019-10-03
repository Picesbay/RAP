#Name: Xuan Anh Nguyen
#Student ID: 524789

#Description: This is the script file to delete old C files
#When user input no argument, the script will list all .c files
#When user input 1 or more arguments, it will just list all those files
#in the arguments.

#Set the script to run on Bourne shell
#! /bin/sh

#Function to ask the user to decide if they want to remove the file or not
function deleteFile ()
{
    file=$1
    head -n 10 $file
    echo -e "\nDelete file $file? (y/n): \c"
    read answer 
    case "$answer" in
       [yY]*) rm -f $file
       echo -e "File $file deleted.\n" ;;
       [nN]*)
       echo -e "File $file NOT deleted.\n" ;;
           *)
       echo -e "Invalid option.\n"
    esac
}


#Main part of the script
echo -e "This script removes C files which you no longer want to keep.\n"
echo -e "Here are the C file(s) under the current directory:\n"

#Check if the .c files exist in the current folder
if [[ $(find . -name "*.c" 2>/dev/null | wc -l) > 0 ]] ;
#If the .c files exist.
then 
    #Check the argument input from the user
    numberOfArguments=$#
    #The user enter no argument. 
    if [ $numberOfArguments -lt 1 ];    
    then
        echo *.c
        for file in *.c; do
           echo "Displaying first 10 lines of $file:"
           deleteFile $file
        done
    
    #The user enter more than 1 argument.
    else
        #For each argument that user input.
        for arg
        do
           echo "Displaying first 10 lines of $arg:"
           #If the file exist.
           if [ -f $arg ] ; then
              deleteFile $arg
           #If the file does not exist  
           else
              echo -e "File $arg does not exist.\n"
           fi
        done    
    fi
    
#If the .c file is not exist in the current folder     
else
   echo -e "No C files found.\n"
fi

