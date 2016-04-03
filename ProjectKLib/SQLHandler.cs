using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ProjectKLib
{
    public class SQLHandler
    {
        SmallOperationsAndFunctions functions = new SmallOperationsAndFunctions();
        private string connStr = @"Data Source=LD-PC;Initial Catalog=VasiaShop;Integrated Security=True";
        public SqlConnection Connect()
        {           
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
                
            }
            return conn;
        }

        public void NewClient(string FirstName, string SecondName, string Tel, string EMail)
        {
            #region Connect
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
            #endregion
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
                if (conn != null)
                {
                    conn.Close();
                }
                conn.Dispose();
                Console.WriteLine("Operation complete");           
             }
        }

        public void ChangeClient()
        {
            throw new System.NotImplementedException();
        }

        public Client GetClient(int ClientNum)
        {
                Client Client = new Client();
                SqlConnection conn = Connect();           
                SqlCommand cmd = new SqlCommand("Select * From Clients where [ID Client] = @ID", conn);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = ClientNum;
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Client.ID = int.Parse(dr[0].ToString());
                Client.FirstName = dr[1].ToString();
                Client.SecondName = dr[2].ToString();
                Client.Phone = dr[3].ToString();
                Client.Email = dr[4].ToString();
                if (conn != null)
                {
                    conn.Close();
                }
                conn.Dispose();

            
            /*
                //Выводим значение на экран
                cmd = new SqlCommand("Select * From Students", conn);
                //Метод ExecuteReader() класса SqlCommand возврашает объект типа SqlDataReader, с помошью которого мы можемпрочитать все строки, возврашенные в результате выполнения запроса CommandBehavior.CloseConnection - закрываем соединение после запроса
               
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    //цикл по всем столбцам полученной в результате запроса таблицы
                    for (int i = 0; i < dr.FieldCount; i++)
                       //метод GetName() класса SqlDataReader позволяет получить имя столбца по номеру, который передается в качестве параметра, данному методу и озночает номер столбца в таблице(начинается с 0)
                        
                        Console.Write("{0}\t", dr.GetName(i).ToString().Trim());
                   //читаем данные из таблицы чтение происходит только в прямом направлении все прочитаные строки отбрасываюся 
                    Console.WriteLine();
                    while (dr.Read())
                    {
                        //метод GetValue() класса SqlDataReader позволяет получить значение столбца по номеру, который передается в качестве параметра, данному метод и озночает номер столбца в таблице(начинается с 0)
                                              
                        Console.WriteLine("{0}\t{1}\t{2}", dr.GetValue(0).ToString().Trim(),
                         dr.GetValue(1).ToString().Trim(),
                         dr.GetValue(2).ToString().Trim());
                    }
                }
               */
            return Client;
        }

        public void NewRent(int IDClient, int Table, DateTime StartDate, DateTime PlannedEndDate)
        {
               
                SqlConnection conn = Connect(); 
                Console.WriteLine("Creating dataset");
                SqlCommand cmd = new SqlCommand("Insert into Rent" +
                "([ID Client],[ID Table],[Starting date],[Possible End Date]) Values (@Client,@Table,@Start,@End)", conn);
                /*Работаем с параметрами(SqlParameter), эта техника позволяет уменьшить
                кол-во ошибок и достичь большего быстродействия
                но требует и больших усилий в написании кода*/
                //объявляем объект класса SqlParameter
                SqlParameter param = new SqlParameter();
                //задаем имя параметра
                param.ParameterName = "@Client";
                //задаем значение параметра
                param.Value = IDClient;
                //задаем тип параметра
                param.SqlDbType = System.Data.SqlDbType.Int;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                //переопределяем объект класса SqlParameter
                param = new SqlParameter();
                param.ParameterName = "@Table";
                param.Value = Table;
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Start";
                param.Value = StartDate;
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@End";
                param.Value = PlannedEndDate;
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);
                Console.WriteLine("Attempt to write into Rent");
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Error on writing");
                }
                if (conn != null)
                {
                    conn.Close();
                }
                conn.Dispose();
                Console.WriteLine("Operation complete");
            
        }

        public int getClientID(string name)
        { 
                Dictionary<string, int> ClientList = new Dictionary<string,int>();
                
                SqlConnection conn = Connect(); 
                name = functions.NameSplitter(name);
                //Выводим значение на экран
                SqlCommand cmd = new SqlCommand("[dbo].[GetPossibleClients]", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name";
                param.Value = name;
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.CreateParameter();
                cmd.Parameters.Add(param);


                //Метод ExecuteReader() класса SqlCommand возврашает объект типа SqlDataReader, с помошью которого мы можемпрочитать все строки, возврашенные в результате выполнения запроса CommandBehavior.CloseConnection - закрываем соединение после запроса

                SqlDataReader dr = cmd.ExecuteReader();   
                    while (dr.Read())
                    {
                        //Console.WriteLine(dr[0]);
                       int ID;
                       string Tmp = dr[0].ToString();
                       int.TryParse(Tmp, out ID);
                       string Namer = dr[1] + " " + dr[2];
                       ClientList.Add(Namer, ID);
                    }
                 if (conn != null)
                {
                    conn.Close();
                }
                conn.Dispose();
            
            //Console.WriteLine(ClientList.ElementAt(0));
            if (ClientList.Count == 1)
            {
                return ClientList.ElementAt(0).Value;
            }
            else
            {
                Console.WriteLine("Select correct person and write correct number");
                for (int i = 0; i < ClientList.Count; i++)
                {
                    Console.WriteLine(i +". Name: " + ClientList.ElementAt(i).Key);

                }
                //this code will be changed on according GUI

                int p;
                int.TryParse(Console.ReadLine(), out p);
                return ClientList.ElementAt(p).Value;
            }
        }

        public Rent GetRent(int RentNum)
        {
                Rent Rent = new Rent();
                
                SqlConnection conn = Connect(); 
                SqlCommand cmd = new SqlCommand("Select * From Rent where [ID Rent] = @ID", conn);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = RentNum;
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Rent.ID = int.Parse(dr[0].ToString());
                Rent.ClientID = int.Parse(dr[1].ToString());
                Rent.TableID = int.Parse(dr[2].ToString()); 
                Rent.StartDate = DateTime.Parse(dr[3].ToString());
                Rent.PosEndDate = DateTime.Parse(dr[4].ToString());
                Rent.RealEndDate = DateTime.Parse(dr[5].ToString());
                if (conn != null)
                {
                    conn.Close();
                }
                conn.Dispose();

            
            return Rent;
        }

        public void ChangeRent()
        {
            throw new System.NotImplementedException();
        }

        public void NewEvent(int IDRent, string Service, int Amount)
        {
            Services ServiceNum;
            int ServID = 0;
                
                SqlConnection conn = Connect(); 
                Console.WriteLine("Creating dataset");
                SqlCommand cmd = new SqlCommand("Insert into Events" +
                "([ID Rent],[ID Service],Amount,Date) Values (@Rent,@Service,@Amount,@Date)", conn);                
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Rent";
                param.Value = IDRent;
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Service";
                for (ServiceNum = Services.MemPage; ServiceNum <= Services.CleanTable; ServiceNum++ )
                {
                    if(ServiceNum.ToString() == Service)
                    ServID = (int)ServiceNum;
                }
                param.Value = ServID;
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Amount";
                param.Value = Amount;
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Date";
                param.Value = System.DateTime.Now;
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);
                Console.WriteLine("Attempt to write into Events");
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Error on writing");
                }
                if (conn != null)
                {
                    conn.Close();
                }
                conn.Dispose();
            
        }

        public Event GetEvent(int EvID)
        {
          
                SqlConnection conn = Connect(); 
                Event Event = new Event();
                SqlCommand cmd = new SqlCommand("Select * From Events where [ID Events] = @ID", conn);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = EvID;
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Event.ID = int.Parse(dr[0].ToString());
                Event.RentID = int.Parse(dr[1].ToString());
                Event.Service = int.Parse(dr[2].ToString());
                Event.Amount = int.Parse(dr[3].ToString());
                Event.Date = DateTime.Parse(dr[4].ToString());
                if (conn != null)
                {
                    conn.Close();
                }
                conn.Dispose();

                return Event; 
        }
    }
}
