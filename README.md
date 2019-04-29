# Online-Voting-System ------Case Study (Epic Construction)

Epic Construction is an organisation with 600 staff in various departments.  Once a year, the company conducts a ballot among staff to elect five representatives from different departments to represent staff at company’s monthly Board of Directors meeting.
Current process to elect staff representatives are as follows:
1.	Staff who wish to stand for election must submit their nomination (via email) a month before the election date.

2.	From the list of nominations, five staff are chosen to stand for elections. Ballot papers are printed with the five candidates.

3.	On election day, ballot box is placed in the administration area at head office where staff can place their vote.

4.	Before staff cast their vote, admin must check their staff ID and tick off that staff from a list of staff in the company.  This prevents a staff from voting twice.

5.	When the voting is completed, the votes are counted and the results declared. Sample election results created by office administrator is available below. This is currently done in MS excel :

Staff Representative Voting STATISTICS
=====================================

Numbers on voting list:	678
Numbers voted:	494 (73%)

Voting Results
-------------------
	Candidate 5:	123	(24.9%)
	Candidate 1:	89	(18.0%)
	Candidate 3:	76	(15.4%)
	Candidate 2:	67	(13.6%)
	Candidate 4:	54	(10.9%)

The management has realised that substantial resources are used in terms of time and money to conduct this manual process of voting.  Hence, they have decided to computerise the process. 
You are part of a team that is assigned to develop a web based voting system to elect staff representatives to the board of Directors meeting.  The development will be carried out in several iterations.  This assignment concerns the first iteration, which is to create a prototype of a web based application to elect five staff representatives. 
The ultimate goal of management is to offer a secure online voting system that can be accessed via company intranet.
 

Iteration One
=====================================

You will need to complete the project for Iteration one based on information provided in the Case Study and Additional details obtained during JAD sessions for this project. You can have two JAD sessions for this assignment. Your first JAD session is booked for Thursday 3rd May.

Expected outcome from iteration one
Development of database and web application to manage election of staff representative. 
Your application will have a home page that displays the system name, a welcome message and provide links for a user to choose between a Voter, Administrator or Help option.

Administrator option
=====================================

Administrator link will take user to a page where they can login with their username and password. Appropriate error messages should be displayed for incorrect admin username and password. Once an administrator successfully login to the system, they will be redirected to admin menu page, where they can manage System Admin, candidate, staff, voting date restrictions and view reports.

Voter option:
=====================================

Voter link will take user to a page where they can register as a new user or login with their username and password. Appropriate error messages should be displayed for incorrect voter username and password. 
Once a voter successfully login to the system, they will be redirected to a page, where they can cast their vote. 
•	If the staff is eligible to vote (cannot vote twice!), the system welcomes the staff by name and displays a list of candidates to choose from.
•	The voter then choose the candidate he/she wishes to vote for.
•	The system displays the name of the candidate chosen and asks the staff to confirm the choice.
•	If the staff accepts the choice, the system records this vote, thanks the staff and returns to the main screen.
•	Every time a staff votes, that staff is flagged as voted and the candidate count is incremented by one. Each candidate carries his/her own vote counts.

Help option:
=====================================

Help link will take user to a page where they can access details about the voting process and how your system works. This could be presented in a Question/Answer format or a help menu. (Note: Content should be extracted from database and not hardcoded into the website)

