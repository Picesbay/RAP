#Name: Xuan Anh Nguyen
#Student ID: 524789

#Description: This script allows the user to add, view or 
#delete a setting in a configuration file.

#Set the script to run on Bourne shell
#! /bin/sh


#Function to add a new setting.
function add_new_setting ()
{
	#Loop until the user correct setting a new variable.
	loop=y
	while [ $loop = y ]
	do
		echo -e "\nEnter setting (format: ABCD=abcd): \c"
		read varAdd
		
		#If the user only press enter/return
		if [ -z $varAdd ] ; 
		then
			echo -e "New setting not entered\n" ; continue ;
			
		else
			#If the user enter only the variable name without "=" sign
			if [ $(expr index $varAdd '=') = 0 ] ; then
				echo -e "Invalid setting\n"	; 
				
			#If the user enter only the variable name with "=" sign	
			elif [ 	${varAdd: -1} = "=" ] ; then
				echo -e "The variable name of the setting is: ${varAdd%=*} " 
				echo -e "The variable value of the setting is: "
				echo -e "Invalid setting.\n" ; 
				
			#If the user enter only enter the variable value with the "=" before variable value 	
			elif [ ${varAdd:0:1} = "=" ] ; then
				echo -e "The variable name of the setting is: "
				echo -e "The variable value of the setting is: ${varAdd#*=}"
				echo -e "Invalid setting.\n" ;
				
			#If the user enter both the variable name and value 
			#but the first character is a number
			elif [ ${varAdd:0:1} -eq ${varAdd:0:1} ] 2>/dev/null ; then
				echo -e "The variable name of the setting is: ${varAdd%=*} "
				echo -e "The variable value of the setting is: ${varAdd#*=}"
				echo -e "Invalid setting. The first character of a variable name cannot be a digit.\n"
		
			else
				#Check if the user enter the exist variable name	
				checkVariableName=$(grep ${varAdd%=*} config.txt)  
				if [[ -z $checkVariableName ]]; then						
					echo -e "The variable name of the setting is: ${varAdd%=*} "
					echo -e "The variable value of the setting is: ${varAdd#*=}"
					echo $varAdd >> config.txt
					echo -e "New setting added.\n" ; 
					break ;	
			
				#The user enter the correct new setting convention + Add new setting to config.txt	
				else
					echo -e "The variable name of the setting is: ${varAdd%=*} "
					echo -e "The variable value of the setting is: ${varAdd#*=}"
					echo -e "Variable exists. Changing the values of existing variables is not allowed." ; 
					break ; 
				fi
			fi
		fi
	done
}

#Main part of the script
#Check if the config.txt file is exist
if [[ ! -f config.txt ]]
#If the file does not exist 
then 
   echo -e "The configuration file does not exist.\n"
#If the file exists.   
else
   #Loop continuously the menu until quit.
   answer=y
   while [ $answer = y ]
   do
	  #print the menu option
      echo -e "\n*** MENU ***"
      echo -e "\n 1. Add a Setting"
      echo -e "\n 2. Delete a Setting"
      echo -e "\n 3. View a Setting"
      echo -e "\n 4. View All Settings"
      echo -e "\n Q. Q - Quit\n\n"
      echo -e "CHOICE: \c"
	  
	  read choice
	  case $choice in
	  #user choose 1: add a new setting
	  1) add_new_setting ;;	     
	  
	  #user choose 2: delete a setting
	  2) echo -e "\nEnter Variable Name:\c"
		 read variableName 
		 #Check variable
	     checkName=$(grep $variableName config.txt) 
		 if [ -z $checkName ];
		 then 
			echo -e "\nVariable does not exist."
		 else
			echo -e "\n`grep $variableName config.txt`\n"
			#Check if user want to delete variable or not.
			echo -e "Delete This Setting (y/n)?\c" ;
			read userInput ;
			case $userInput in
			#If the user choose yes delete the variable and save the result in new file newConfig.txt.
			y|Y)sed /$variableName/d ./config.txt > newConfig.txt ;
				#Replace the config.txt content with the content of the new file newConfig.txt
				cat newConfig.txt > config.txt ; 
				echo "Setting Deleted" ;;
			  *) ;;
			esac 
		 fi ;;
		 
	  #user choose 3: display a setting
	  3) echo -e "\nEnter Variable Name:\c"
		 read variableName
		 #Check variable
	     checkName=$(grep $variableName config.txt) 
		 if [[ -z $checkName ]];
		 then 
			echo -e "\nVariable does not exist."
		 else
			echo -e "\n`grep $variableName config.txt`\n"
			echo -e "Requested Setting Displayed Above.\n"
		 fi ;;
	  
	  #user choose 4: display all the settings
	  4) echo -e "\n`cat config.txt`\n" ;;
	  
	  #user choose quit
	  q|Q) echo -e "\nThank You!" ; break ;;
	  
	  #user choose an invalid option
	  *) echo -e "\nInvalid Option\n" ;
		 echo -e "\nPlease choose from 1 to 4 or q to quit!\n" ;;	  
	  esac
   done
fi
