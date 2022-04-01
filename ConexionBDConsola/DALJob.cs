using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBDConsola
{
    class DALJob
    {
        Job temp;
        DbConnect cnx;
        List<Job> jobs = new List<Job>();

        public DALJob()
        {
            cnx = new DbConnect();
        }

        public void InsertJob(Job job)
        {
            try
            {
                cnx.OpenConection();

                string sql = @"INSERT INTO jobs (job_title, min_salary, max_salary)
                VALUES(@puesto, @min, @max)";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlParameter min = new SqlParameter("@min", job.minSalary);
                SqlParameter max = new SqlParameter("@max", job.maxSalary);

                SqlParameter puesto = new SqlParameter("@puesto", System.Data.SqlDbType.NVarChar, 50);
                puesto.Value = job.workstation;
                cmd.Parameters.Add(puesto);
                cmd.Parameters.Add(min);
                cmd.Parameters.Add(max);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Insertado correctamente");
                cnx.CloseConnection();

            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido insertar " + ee);
            }
        }

        public List<Job> SelectJobs()
        {
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT *
                FROM jobs";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    temp = new Job(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDecimal(dr[2]), Convert.ToInt32(dr[3]));
                    jobs.Add(temp);

                }
                dr.Close();
                cnx.CloseConnection();
                return jobs;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido hacer el select " + ee);
                return null;
            }
        }

        public List<Job> SelectJobsManagers()
        {
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT *
                FROM jobs
                WHERE job_title like '%Manager%'";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    temp = new Job(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDecimal(dr[2]), Convert.ToInt32(dr[3]));
                    jobs.Add(temp);

                }
                dr.Close();
                cnx.CloseConnection();
                return jobs;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido hacer el select " + ee);
                return null;
            }
        }

        public List<Job> SelectJobsSalary(Decimal filt)
        {
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT *
                FROM jobs
                WHERE @filt > min_salary AND @filt < max_salary";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter filtr = new SqlParameter("@filt", filt);
                
                cmd.Parameters.Add(filtr);
              

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    temp = new Job(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDecimal(dr[2]), Convert.ToInt32(dr[3]));
                    jobs.Add(temp);

                }
                dr.Close();
                cnx.CloseConnection();
                return jobs;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido hacer el select " + ee);
                return null;
            }
        }


        public Job Select1Job(int id)
        {
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT *
                FROM jobs WHERE job_id = @id";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter ide = new SqlParameter("@id", id);
                cmd.Parameters.Add(ide);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temp = new Job(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDecimal(dr[2]), Convert.ToInt32(dr[3]));

                }



                dr.Close();
                cnx.CloseConnection();
                return temp;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido encontrar el trabajo " + ee);
                return null;
            }
        }
        public void DelJob(int job)
        {
            try
            {
                cnx.OpenConection();
                string sql = @"
                DELETE
                FROM jobs
                WHERE job_id = @id";



                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter id = new SqlParameter("@id", job);
                cmd.Parameters.Add(id);
                cmd.ExecuteNonQuery();
                cnx.CloseConnection();
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido ejecutar el delete " + ee);
            }
        }

        public void UpdateJob(Job job)
        {
            try
            {
                cnx.OpenConection();

                string sql = @"UPDATE jobs
                                SET job_title = @puesto, min_salary = @min, max_salary = @max
                                WHERE  job_id = @id";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlParameter min = new SqlParameter("@min", job.minSalary);
                SqlParameter max = new SqlParameter("@max", job.maxSalary);
                SqlParameter id = new SqlParameter("@id", job.id);

                SqlParameter puesto = new SqlParameter("@puesto", System.Data.SqlDbType.NVarChar, 50);
                puesto.Value = job.workstation;
                cmd.Parameters.Add(puesto);
                cmd.Parameters.Add(min);
                cmd.Parameters.Add(max);
                cmd.Parameters.Add(id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Actualizado correctamente");
                cnx.CloseConnection();

            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido actualizar " + ee);
            }
        }
    }
}
