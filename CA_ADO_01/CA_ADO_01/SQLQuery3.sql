CREATE PROCEDURE [dbo].[SP_emp_GET_LIST]  
AS  
   BEGIN  
   SELECT Id ,Name   ,Salary
   FROM Employee
END