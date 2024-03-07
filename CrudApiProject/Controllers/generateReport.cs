using CrudApiProject.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;


namespace CrudApiProject.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class generateReport :ControllerBase
  {
    private readonly APIDemoDbClass _apiDemoDbClass;
    public readonly IConfiguration _configuration;
    public generateReport( APIDemoDbClass apiDemoDbClass, IConfiguration configuration )
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
      List<Report> report = new List<Report>();


      Response response = new Response();

      if ( dt.Rows.Count > 0 )
      {
        for ( int i = 0; i < dt.Rows.Count; i++ )
        {
          Report u = new Report();
          u.product_quantity = Convert.ToInt32( dt.Rows[ i ][ "Product_quantity" ] );
          u.first_name = Convert.ToString( dt.Rows[ i ][ "first_name" ] );
          u.last_name = Convert.ToString( dt.Rows[ i ][ "last_name" ] );
          u.name = Convert.ToString( dt.Rows[ i ][ "name" ] );
          u.order_id = Convert.ToInt32( dt.Rows[ i ][ "orderID" ] );

          report.Add( u );
        }
      }
      if ( report.Count > 0 )
      {
        return JsonConvert.SerializeObject( report );
      }
      else
      {
        response.StatusCode = 100;
        response.ErrorMessage = "No data found";
        return JsonConvert.SerializeObject( response );
      }
    }




    [HttpGet]
    [Route( "get-report/{username}/{productname}" )]
    
    public String  GetReport(String username ,String productname )
    {
      SqlConnection con = new SqlConnection( _configuration.GetConnectionString("DbConnection").ToString());
      SqlDataAdapter adapter = new SqlDataAdapter( "Exec generateReport @name="+ productname + " ,@username ="+username, con);
      DataTable dt = new DataTable(); 
      adapter.Fill(dt);
      List<Report> report= new List<Report>();


      Response response = new Response();

      if(dt.Rows.Count > 0)
      {
        for(int i = 0; i < dt.Rows.Count; i++ )
        {
          Report u = new Report();
          u.product_quantity = Convert.ToInt32( dt.Rows[ i ][ "product_quantity" ] );
          u.first_name = Convert.ToString( dt.Rows[ i ][ "first_name" ] );
          u.last_name = Convert.ToString( dt.Rows[ i ][ "last_name" ] );
          u.name = Convert.ToString( dt.Rows[ i ][ "name" ] );
          u.order_id = Convert.ToInt32( dt.Rows[ i ][ "orderID" ] );
          report.Add( u );  
        }
      }
      if(report.Count > 0)
      {
        return JsonConvert.SerializeObject( report );
      }
      else
      {
        response.StatusCode = 100;
        response.ErrorMessage = "No data found";
        return JsonConvert.SerializeObject( response );
      }
    }

    [HttpGet]
    
    [Route( "get-report-/{productname}" )]
    public String GetReport( String productname)
    {
      SqlConnection con = new SqlConnection( _configuration.GetConnectionString( "DbConnection" ).ToString() );
      SqlDataAdapter adapter = new SqlDataAdapter( "Exec generateReportbyproductname @name=" + productname , con );
      DataTable dt = new DataTable();
      adapter.Fill( dt );
      List<Report> report = new List<Report>();

      Response response = new Response();

      if ( dt.Rows.Count > 0 )
      {
        for ( int i = 0; i < dt.Rows.Count; i++ )
        {
          Report u = new Report();
          u.product_quantity = Convert.ToInt32( dt.Rows[ i ][ "product_quantity" ] );
          u.first_name = Convert.ToString( dt.Rows[ i ][ "first_name" ] );
          u.last_name = Convert.ToString( dt.Rows[ i ][ "last_name" ] );
          u.name = Convert.ToString( dt.Rows[ i ][ "name" ] );
          u.order_id = Convert.ToInt32( dt.Rows[ i ][ "orderID" ] );
          report.Add( u );
        }
      }
      if ( report.Count > 0 )
      {
        return JsonConvert.SerializeObject( report );
      }
      else
      {
        response.StatusCode = 100;
        response.ErrorMessage = "No data found";
        return JsonConvert.SerializeObject( response );
      }
    }

    [HttpGet]

    [Route( "get-report-daterange/{date1}/{date2}" )]
    public String GetReportByDateRange( String date1,String date2 )
    {

      SqlConnection con = new SqlConnection( _configuration.GetConnectionString( "DbConnection" ).ToString() );
      SqlDataAdapter adapter = new SqlDataAdapter( "Exec generateReportByDateRange @date1=" + date1+ ", @date2="+date2, con );
     
      DataTable dt = new DataTable();
      adapter.Fill( dt );
      List<Report> report = new List<Report>();

      Response response = new Response();

      if ( dt.Rows.Count > 0 )
      {
        for ( int i = 0; i < dt.Rows.Count; i++ )
        {
          Report u = new Report();
          u.product_quantity = Convert.ToInt32( dt.Rows[ i ][ "product_quantity" ] );
          u.first_name = Convert.ToString( dt.Rows[ i ][ "first_name" ] );
          u.last_name = Convert.ToString( dt.Rows[ i ][ "last_name" ] );
          u.name = Convert.ToString( dt.Rows[ i ][ "name" ] );
          u.order_id = Convert.ToInt32( dt.Rows[ i ][ "orderID" ] );

          report.Add( u );
        }
      }
      if ( report.Count > 0 )
      {
        return JsonConvert.SerializeObject( report );
      }
      else
      {
        response.StatusCode = 100;
        response.ErrorMessage = "No data found";
        return JsonConvert.SerializeObject( response );
      }
    }

  }

  
}
