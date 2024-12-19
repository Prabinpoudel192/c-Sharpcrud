using System;
using MySql.Data.MySqlClient;
namespace @crud{
class A{
public static void Main(){
    while(true){
        B obj=new B();
        Console.WriteLine("please enter 1-for insertion,2-for display,3-for update operation,4-for delete operation");
        int.TryParse(Console.ReadLine(),out int a);
        if(a==1){
            obj.insert();
            obj.display();
            continue;
        }else if(a==2){
            obj.display();
            continue;
        }else if(a==3){
            obj.update();
            obj.display();
            continue;
        }else if(a==4){
            obj.delete();
            obj.display();
            continue;
        }
        
        else{
            break;
        }
    }
}
}
class B{
    string dbcon="Server=localhost;Database=ptest;User Id=root;Password=;";
//This portion does the create operation.
    public void insert(){
        Console.WriteLine("Please enter the details:");
        Console.Write("Name:");
        string name=Console.ReadLine();
        Console.Write("Email:");
        string email=Console.ReadLine();
        using(MySqlConnection con=new MySqlConnection(dbcon)){
            con.Open();
            string query=$"insert into details(name,email)values('{name}','{email}')";
            MySqlCommand k=new MySqlCommand(query,con);
            k.ExecuteNonQuery();
            Console.WriteLine("Data inserted successfully");
        }
    
    }
    //Create opertion code ends here
    //Display operation starts here
    public void display(){
        using(MySqlConnection con=new MySqlConnection(dbcon)){
            con.Open();
            string query="select *from details";
            using(MySqlCommand com=new MySqlCommand(query,con)){
                using(MySqlDataReader read=com.ExecuteReader()){
                    while(read.Read()){
                        Console.WriteLine($"Name:{read["name"]}\tEmail:{read["email"]}");
                    }

                }
            }
            Console.WriteLine("We've reached the end of Database");
            Console.WriteLine("\n\n");
        }
    }
    //Display operation ends here
    //Update operation start here
    public void update(){
        Console.WriteLine("Please enter the name you want to update:");
        string oldname=Console.ReadLine();
        Console.Write("New Name:");
        string newname=Console.ReadLine();
        Console.Write("New Email:");
        string newemail=Console.ReadLine();
        using(MySqlConnection con=new MySqlConnection(dbcon)){
            con.Open();
            string query=$"update details set name='{newname}',email='{newemail}' where name='{oldname}'";
            MySqlCommand com=new MySqlCommand(query,con);
            com.ExecuteNonQuery();
            Console.WriteLine("Data update successful");
        }
    }
    //Update operation ends here
    //Delete operation starts here
    public void delete(){
        Console.WriteLine("Please provide name to delete the details:");
        string delete=Console.ReadLine();
        using(MySqlConnection con=new MySqlConnection(dbcon)){
            con.Open();
            string query=$"delete from details where name='{delete}'";
            MySqlCommand com=new MySqlCommand(query,con);
            com.ExecuteNonQuery();
            Console.WriteLine($"Detail of {delete} is removed from database");
        }
    }

}}