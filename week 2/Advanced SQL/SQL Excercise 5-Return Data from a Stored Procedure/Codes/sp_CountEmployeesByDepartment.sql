--Exercise 5: Return Data from a Stored Procedure

CREATE PROCEDURE sp_CountEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        COUNT(*) AS TotalEmployees
    FROM 
        Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;

EXEC sp_CountEmployeesByDepartment @DepartmentID = 3;

--DROP PROCEDURE sp_CountEmployeesByDepartment;