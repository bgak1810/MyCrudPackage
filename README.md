# MyCrudPackage
Purpose
-----------
This package is useful to everyone who uses .net framework and try to push the model data to the sql database.

Implementation Steps
-----------------------
we have 3 methods in this package

1. DBTransaction	- Applicable to send model as a parameter and do the CUD operations
2. GetDataSet		= Applicable to receive the dataset with multiple or single table
3. GetDataTable		- Applicable to receive the datatable 

Scenario 1:
Assuming you want to do a transaction to create / update / delete a record
Model (From your Application)
------
public class Employee
{
	public string FirstName{get;set;}
	public string LastName{get;set;}
	public string MiddleName{get;set;}
	public int Age{get;set;}
	public bit Gender{get;set;}
}
you are forming this object in your creation screen (Employee.aspx.cs)

Button_Click event
--------------------
Employee employee=new Employee();
employee.FirstName=txtFirstName.Text;
employee.LastName=txtLastName.Text;
employee.MiddleName=txtMiddleName.Text;
employee.Age=Convert.ToInt16(txtAge.Text);
employee.Gender=Convert.ToBoolean(rbdGender.Value);

here we call our MyCrudPackage
-------------------------------
var result=MyCrudPackage.CRUD.DBTransactions&lt;Employee&gt;(employee,&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);

Scenario 2:
-----------
To receive data to a Dataset with parameters (multiple collection of select statement from stored proc / single)

DataSet ds=new DataSet();
ds=MyCrudPackage.CRUD.GetDataSet&lt;Employee&gt;(employee,&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);

Scenario 3:
-----------
To receive data to a Dataset without parameters (multiple collection of select statement from stored proc / single)

DataSet ds=new DataSet();
ds=MyCrudPackage.CRUD.GetDataSet(&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);

Scenario 4:
-----------
To receive data to a Datatable with parameters

DataTable dt=new DataTable();
dt=MyCrudPackage.CRUD.GetDataTable&lt;Employee&gt;(employee,&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);

Scenario 5:
-----------
To receive data to a Datatable without parameters 

DataTable dt=new DataTable();
dt=MyCrudPackage.CRUD.GetDataTable(&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);





