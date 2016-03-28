using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ProjectKLib
{
    public class SQLHandler
    {
        public void TestConnection(){
            string connStr = @"Data Source=LD-PC;Initial Catalog=VasiaShop;Integrated Security=True";
           
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //try to open
                conn.Open();
            }
            catch (SqlException se)
            {
                
                if (se.Number == 4060)
                {
                    //Error message
                    Console.WriteLine("No such DB");
                    //close
                    conn.Close();
                                      
                }
            }
            finally
            {
                Console.WriteLine("Connected");
                conn.Close();
                conn.Dispose();
            }
 
        }

        public void NewClient(string FirstName, string SecondName, string Tel, string EMail)
        {
                        string connStr = @"Data Source=LD-PC;Initial Catalog=VasiaShop;Integrated Security=True";
           
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //try to open
                conn.Open();
            }
            catch (SqlException se)
            {
                
                if (se.Number == 4060)
                {
                    //Error message
                    Console.WriteLine("No such DB");
                    //close
                    conn.Close();                   
                }
            }
            finally
            {
                Console.WriteLine("Creating dataset");
                SqlCommand cmd = new SqlCommand("Insert into Clients" +
                "([First Name],[Second Name],Tel,[E-mail]) Values (@FName,@SName,@Tel,@Mail)", conn);
                /*Работаем с параметрами(SqlParameter), эта техника позволяет уменьшить
                кол-во ошибок и достичь большего быстродействия
                но требует и больших усилий в написании кода*/
                //объявляем объект класса SqlParameter
                SqlParameter param = new SqlParameter();
                //задаем имя параметра
                param.ParameterName = "@FName";
                //задаем значение параметра
                param.Value = FirstName;
                //задаем тип параметра
                param.SqlDbType = System.Data.SqlDbType.NVarChar;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                //переопределяем объект класса SqlParameter
                param = new SqlParameter();
                param.ParameterName = "@SName";
                param.Value = SecondName;
                param.SqlDbType = System.Data.SqlDbType.NVarChar;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Tel";
                param.Value = Tel;
                param.SqlDbType = System.Data.SqlDbType.NVarChar;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Mail";
                param.Value = EMail;
                param.SqlDbType = System.Data.SqlDbType.NVarChar;
                cmd.Parameters.Add(param);
                Console.WriteLine("Attempt to write into Clients");
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Error on writing");                   
                }



                //Выводим значение на экран
                cmd = new SqlCommand("Select * From Students", conn);
                /*Метод ExecuteReader() класса SqlCommand возврашает
                 объект типа SqlDataReader, с помошью которого мы можем
                 прочитать все строки, возврашенные в результате выполнения запроса
                 CommandBehavior.CloseConnection - закрываем соединение после запроса
                 */
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    //цикл по всем столбцам полученной в результате запроса таблицы
                    for (int i = 0; i < dr.FieldCount; i++)
                        /*метод GetName() класса SqlDataReader позволяет получить имя столбца
                         по номеру, который передается в качестве параметра, данному методу
                         и озночает номер столбца в таблице(начинается с 0)
                         */
                        Console.Write("{0}\t", dr.GetName(i).ToString().Trim());
                    /*читаем данные из таблицы
                     чтение происходит только в прямом направлении
                     все прочитаные строки отбрасываюся */
                    Console.WriteLine();
                    while (dr.Read())
                    {
                        /*метод GetValue() класса SqlDataReader позволяет получить значение столбца
                                                по номеру, который передается в качестве параметра, данному методу
                                                и озночает номер столбца в таблице(начинается с 0)
                                                */
                        Console.WriteLine("{0}\t{1}\t{2}", dr.GetValue(0).ToString().Trim(),
                         dr.GetValue(1).ToString().Trim(),
                         dr.GetValue(2).ToString().Trim());
                    }
                }
                
                conn.Close();
                conn.Dispose();
            
                
             }
        }

        public void ChangeClient()
        {
            throw new System.NotImplementedException();
        }

        public void GetClient()
        {
            throw new System.NotImplementedException();
        }

        public void NewRent(int IDClient, int Table, DateTime StartDate, DateTime PlannedEndDate)
        {
            throw new System.NotImplementedException();
        }

        public void GetRent()
        {
            throw new System.NotImplementedException();
        }

        public void ChangeRent()
        {
            throw new System.NotImplementedException();
        }

        public void NewEvent(int IDRent, Services Service, int Amount)
        {
            throw new System.NotImplementedException();
        }

        public void GetEvent()
        {
            throw new System.NotImplementedException();
        }
    }
}
