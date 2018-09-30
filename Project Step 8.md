#### Aaron Colclough
#### Sep 30, 2018


# ISTA Project

## Step 8

###### Requirements
1. Database to hold questions and answers.
2. User interface to access and present the data in the database.

###### Analysis
The user interface must have access to the database storing the questions and answers intended for study. The user will be able to choose from multiple Categories and Subcategories of questions in order to refine their type of studying. The interface must be able to present the user with the question and, following a user action, present the corresponding answer.

###### Design
**Categories**

| Column | Type | Null | Identity | Key |
| --- |
| catID | int | No | Unique (1,1) | PK |
| catName | varchar (50) | No | | | |

||

||

||

V

**Subcategories**

| Column | Type | Null | Identity | Key |
| --- |
| subID | int | No | Unique (1,1) | PK |
| subName | varchar (50) | No | | |
| catID | int | No | | FK (Categories) |

||
||
||
V

**QA_Details**

| Column | Type | Null | Identity | Key |
| --- |
| Question | varchar (1000) | No | | |
| Answer | varchar (3000) | No | | |
| qaID | int | No | Unique (1,1) | PK |
| subID | int | No | | FK (Subcategories) |


###### Implementation

###### Testing
