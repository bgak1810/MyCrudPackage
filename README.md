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
public class Employee&lt;/br&gt;;
{&lt;/br&gt;
	public string FirstName{get;set;}&lt;/br&gt;
	public string LastName{get;set;}&lt;/br&gt;
	public string MiddleName{get;set;}&lt;/br&gt;
	public int Age{get;set;}&lt;/br&gt;
	public bit Gender{get;set;}&lt;/br&gt;
}&lt;/br&gt;
you are forming this object in your creation screen (Employee.aspx.cs)&lt;/br&gt;

Button_Click event
--------------------
Employee employee=new Employee();&lt;/br&gt;
employee.FirstName=txtFirstName.Text;&lt;/br&gt;
employee.LastName=txtLastName.Text;&lt;/br&gt;
employee.MiddleName=txtMiddleName.Text;&lt;/br&gt;
employee.Age=Convert.ToInt16(txtAge.Text);&lt;/br&gt;
employee.Gender=Convert.ToBoolean(rbdGender.Value);&lt;/br&gt;

here we call our MyCrudPackage
-------------------------------
var result=MyCrudPackage.CRUD.DBTransactions&lt;Employee&gt;(employee,&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);

Scenario 2:
-----------
To receive data to a Dataset with parameters (multiple collection of select statement from stored proc / single)

DataSet ds=new DataSet();
ds=MyCrudPackage.CRUD.DBTransactions&lt;Employee&gt;(employee,&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);

Scenario 3:
-----------
To receive data to a Dataset without parameters (multiple collection of select statement from stored proc / single)

DataSet ds=new DataSet();
ds=MyCrudPackage.CRUD.DBTransactions(&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);

Scenario 4:
-----------
To receive data to a Datatable with parameters

DataTable dt=new DataTable();
dt=MyCrudPackage.CRUD.DBTransactions&lt;Employee&gt;(employee,&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);

Scenario 5:
-----------
To receive data to a Datatable without parameters 

DataTable dt=new DataTable();
dt=MyCrudPackage.CRUD.DBTransactions(&lt;Storedprocname&gt;,&lt;sqlconnectionstring&gt;);





