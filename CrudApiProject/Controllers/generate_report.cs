using CrudApiProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Data;



namespace CrudApiProject.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class generate_report :ControllerBase
  {
    private readonly api_demo_db_class _apiDemoDbClass;
    public readonly IConfiguration _configuration;
    public generate_report( api_demo_db_class apiDemoDbClass, IConfiguration configuration )
    {
      _apiDemoDbClass = apiDemoDbClass;
      _configuration = configuration;
    }


    //generic report//
    [HttpGet]
    [Route( "get-complete-report" )]

    public String GetReportComplete(  )
    {
      SqlConnection con = new SqlConnection( _configuration.GetConnectionString( "DbConnection" ).ToString() );
      SqlDataAdapter adapter = new SqlDataAdapter( "Exec generateReportComplete" , con );
      DataTable dt = new DataTable();
      adapter.Fill( dt );

      var data = dt.Rows.OfType<DataRow>()
               .Select( row => dt.Columns.OfType<DataColumn>()
                   .ToDictionary( col => col.ColumnName, c => row[ c ] ) );
      return System.Text.Json.JsonSerializer.Serialize( data );


    
    }




    [HttpGet]
    [Route( "get-report/{username}/{productname}" )]
    
    public String  GetReport(String username ,String productname )
    {
      SqlConnection con = new SqlConnection( _configuration.GetConnectionString("DbConnection").ToString());
      SqlDataAdapter adapter = new SqlDataAdapter( "Exec generateReport @name="+ productname + " ,@username ="+username, con);
      DataTable dt = new DataTable(); 
      adapter.Fill(dt);


      var data = dt.Rows.OfType<DataRow>()
           .Select( row => dt.Columns.OfType<DataColumn>()
               .ToDictionary( col => col.ColumnName, c => row[ c ] ) );
      return System.Text.Json.JsonSerializer.Serialize( data );


    }

    [HttpGet]
    
    [Route( "get-report-/{productname}" )]
    public String GetReport( String productname)
    {
      SqlConnection con = new SqlConnection( _configuration.GetConnectionString( "DbConnection" ).ToString() );
      SqlDataAdapter adapter = new SqlDataAdapter( "Exec generateReportbyproductname @name=" + productname , con );
      DataTable dt = new DataTable();
      adapter.Fill( dt );
      var data = dt.Rows.OfType<DataRow>()
         .Select( row => dt.Columns.OfType<DataColumn>()
             .ToDictionary( col => col.ColumnName, c => row[ c ] ) );
      return System.Text.Json.JsonSerializer.Serialize( data );

    }

    [HttpGet]

    [Route( "get-report-daterange/{date1}/{date2}" )]
    public String GetReportByDateRange( String date1,String date2 )
    {

      SqlConnection con = new SqlConnection( _configuration.GetConnectionString( "DbConnection" ).ToString() );
      SqlDataAdapter adapter = new SqlDataAdapter( "Exec generateReportByDateRange @date1='" + date1+"'"+ ", @date2='"+date2+"'", con );
     
      DataTable dt = new DataTable();
      adapter.Fill( dt );

      var data = dt.Rows.OfType<DataRow>()
         .Select( row => dt.Columns.OfType<DataColumn>()
             .ToDictionary( col => col.ColumnName, c => row[ c ] ) );
      return System.Text.Json.JsonSerializer.Serialize( data );
    
    }

  }

  
}
