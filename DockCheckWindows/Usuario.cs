using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockCheckWindows
{
    internal class Usuario
    {
        // NUMBER NAME    COMPANY FUNCTION    FUNCTION ID  EMAIL VESSEL  CHECK-IN VALIDATION CHECK-OUT VALIDATION    CHECK-IN DATA  CHECK-IN HORA  CHECK-OUT DATA  CHECK-OUT HORA  PROJECT ASO NR-34	NR-10	NR-33	NR-35	LOCAL LEVEL   ESTADO MOTIVO  USUARIO


        public Usuario(int numero, string nome, string empresa, string funcao, int identidade, string email, string vessel, string checked_in_val, string check_out_val, string check_in_data, string check_in_hora, string check_out_data, string check_out_hora, string projeto, string aso, string nr_34, string nr_10, string nr_33, string nr_35, string local, string level, string estado, string motivo, string usuario)
        {
            Number = numero;
            Name = nome;
            Company = empresa;
            Function = funcao;
            Id_number = identidade;
            Email = email;
            Vessel = vessel;
            Checked_in_val = checked_in_val;
            Check_out_val = check_out_val;
            Check_in_data = check_in_data;
            Check_in_hora = check_in_hora;
            Check_out_data = check_out_data;
            Check_out_hora = check_out_hora;
            Projec = projeto;
            Aso = aso;
            Nr_34 = nr_34;
            Nr_10 = nr_10;
            Nr_33 = nr_33;
            Nr_35 = nr_35;
            Local = local;
            Level = level;
            Estado = estado;
            Motivo = motivo;
            User = usuario;

            //   Id = Guid.NewGuid();


        }
        //  public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Function { get; set; }
        public int Id_number { get; set; }
        public string Email { get; set; }
        public string Vessel { get; set; }
        public string Checked_in_val { get; set; }
        public string Check_out_val { get; set; }
        public string Check_in_data { get; set; }
        public string Check_in_hora { get; set; }
        public string Check_out_data { get; set; }
        public string Check_out_hora { get; set; }
        public string Projec { get; set; }
        public string Aso { get; set; }
        public string Nr_34 { get; set; }
        public string Nr_10 { get; set; }
        public string Nr_33 { get; set; }
        public string Nr_35 { get; set; }
        public string Local { get; set; }
        public string Level { get; set; }
        public string Estado { get; set; }
        public string Motivo { get; set; }
        public string User { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Usuario)obj;
            return Number == other.Number &&
                   Name == other.Name &&
                   Company == other.Company &&
                   Function == other.Function &&
                   Id_number == other.Id_number &&
                   Email == other.Email &&
                   Vessel == other.Vessel &&
                   Checked_in_val == other.Checked_in_val &&
                   Check_out_val == other.Check_out_val &&
                   Check_in_data == other.Check_in_data &&
                   Check_in_hora == other.Check_in_hora &&
                   Check_out_data == other.Check_out_data &&
                   Check_out_hora == other.Check_out_hora &&
                   Projec == other.Projec &&
                   Aso == other.Aso &&
                   Nr_34 == other.Nr_34 &&
                    Nr_10 == other.Nr_10 &&
                    Nr_33 == other.Nr_33 &&
                    Nr_35 == other.Nr_35 &&
                    Local == other.Local &&
                    Level == other.Level &&
                    Estado == other.Estado &&
                    Motivo == other.Motivo &&
                   User == other.User;
        }

        // Override GetHashCode as well, using the properties used in Equals method
        public override int GetHashCode()
        {
            return Number.GetHashCode()
                   ^ (Name != null ? Name.GetHashCode() : 0)
                   ^ (Company != null ? Company.GetHashCode() : 0)
                   ^ (Function != null ? Function.GetHashCode() : 0)
                   ^ Id_number.GetHashCode()
                   ^ (Email != null ? Email.GetHashCode() : 0)
                   ^ (Vessel != null ? Vessel.GetHashCode() : 0)
                   ^ (Checked_in_val != null ? Checked_in_val.GetHashCode() : 0)
                   ^ (Check_out_val != null ? Check_out_val.GetHashCode() : 0)
                   ^ (Check_in_data != null ? Check_in_data.GetHashCode() : 0)
                   ^ (Check_in_hora != null ? Check_in_hora.GetHashCode() : 0)
                   ^ (Check_out_data != null ? Check_out_data.GetHashCode() : 0)
                   ^ (Check_out_hora != null ? Check_out_hora.GetHashCode() : 0)
                   ^ (Projec != null ? Projec.GetHashCode() : 0)
                   ^ (Aso != null ? Aso.GetHashCode() : 0)
                   ^ (Nr_34 != null ? Nr_34.GetHashCode() : 0)
                   ^ (Nr_10 != null ? Nr_10.GetHashCode() : 0)
                   ^ (Nr_33 != null ? Nr_33.GetHashCode() : 0)
                   ^ (Nr_35 != null ? Nr_35.GetHashCode() : 0)
                   ^ (Local != null ? Local.GetHashCode() : 0)
                   ^ (Level != null ? Level.GetHashCode() : 0)
                   ^ (Estado != null ? Estado.GetHashCode() : 0)
                   ^ (Motivo != null ? Motivo.GetHashCode() : 0)
                   ^ (User != null ? User.GetHashCode() : 0);
        }
    }
    //convert text to Usuario object
    internal class UsuarioConverter
    {
        public static Usuario Convert(string text)
        {
            var fields = text.Split(';');
            return new Usuario(int.Parse(fields[0]), fields[1], fields[2], fields[3], int.Parse(fields[4]), fields[5], fields[6], fields[7], fields[8], fields[9], fields[10], fields[11], fields[12], fields[13], fields[14], fields[15], fields[16], fields[17], fields[18], fields[19], fields[20], fields[21], fields[22], fields[23]);
        }

        // Convert Usuario object to text
        public static string Convert(Usuario usuario)
        {
            return $"{usuario.Number};{usuario.Name};{usuario.Company};{usuario.Function};{usuario.Id_number};{usuario.Email};{usuario.Vessel};{usuario.Checked_in_val};{usuario.Check_out_val};{usuario.Check_in_data};{usuario.Check_in_hora};{usuario.Check_out_data};{usuario.Check_out_hora};{usuario.Projec};{usuario.Aso};{usuario.Nr_34};{usuario.Nr_10};{usuario.Nr_33};{usuario.Nr_35};{usuario.Local};{usuario.Level};{usuario.Estado};{usuario.Motivo};{usuario.User}";
        }

        // Convert Usuario object to special formatted string
        public static string ConvertToSpecialFormat(Usuario usuario)
        {
            return $"Number:  {usuario.Number}:  Name: {usuario.Name}:  Vessel: {usuario.Vessel}:  Compay: {usuario.Company}  Id: {usuario.Id_number}  :E-Mail: {usuario.Email} : CheckIn {usuario.Check_in_data} {usuario.Check_in_hora}";
        }
    }
}