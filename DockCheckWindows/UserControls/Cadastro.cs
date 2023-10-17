using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockCheckWindows
{
    internal class Cadastro
    {
        public Cadastro(
     string number = "N/A",
     string name = "Unknown",
     string company = "Unknown",
     string function = "Unknown",
     string identidade = "0",
     string email = "N/A",
     string vessel = "N/A",
     string project = "N/A",
     string aso = "00/00/0000",
     string nr_34 = "00/00/0000",
     string nr_10 = "00/00/0000",
     string nr_33 = "00/00/0000",
     string nr_35 = "00/00/0000",
     string estado = "Unknown",
     string usuario = "Unknown",
     string motivo = "N/A",
     string local = "N/A",
     string data = "00/00/0000",
     string data2 = "00/00/0000",
     string document = "N/A")
        {
            Number = number;
            Name = name;
            Company = company;
            Function = function;
            Identidade = identidade;
            Email = email;
            Vessel = vessel;
            Project = project;
            ASO = aso;
            NR_34 = nr_34;
            NR_10 = nr_10;
            NR_33 = nr_33;
            NR_35 = nr_35;
            Estado = estado;
            User = usuario;
            Motivo = motivo;
            Local = local;
            Data = data;
            Data2 = data2;
            Document = document;


        }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Function { get; set; }
        public string Identidade { get; set; }
        public string Email { get; set; }
    public string Vessel { get; set; }
    public string Project { get; set; }
    public string ASO { get; set; }
    public string NR_34 { get; set; }
    public string NR_10 { get; set; }
    public string NR_33 { get; set; }
    public string NR_35 { get; set; }
    public string Estado { get; set; }
    public string User { get; set; }
    public string Motivo { get; set; }
    public string Local { get; set; }
    public string Data { get; set; }
    public string Data2 { get; set; }
    public string Document { get; set; }


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (Cadastro)obj;
        return Number == other.Number &&
        Name == other.Name &&
        Company == other.Company &&
               Function == other.Function &&
               Identidade == other.Identidade &&
               Email == other.Email &&
               Vessel == other.Vessel &&
               Project == other.Project &&
               ASO == other.ASO &&
               NR_34 == other.NR_34 &&
               NR_10 == other.NR_10 &&
               NR_33 == other.NR_33 &&
               NR_35 == other.NR_35 &&
               Estado == other.Estado &&
               User == other.User &&
               Motivo == other.Motivo &&
               Local == other.Local &&
               Data == other.Data &&
               Data2 == other.Data2 &&
               Document == other.Document;
    }

    // Override GetHashCode as well, using the properties used in Equals method
    public override int GetHashCode()
    {
        return Number.GetHashCode()
               ^ (Name != null ? Name.GetHashCode() : 0)
               ^ (Company != null ? Company.GetHashCode() : 0)
               ^ (Function != null ? Function.GetHashCode() : 0)
               ^ (Identidade != null ? Identidade.GetHashCode() : 0)
               ^ (Email != null ? Email.GetHashCode() : 0)
               ^ (Vessel != null ? Vessel.GetHashCode() : 0)
               ^ (Project != null ? Project.GetHashCode() : 0)
               ^ (ASO != null ? ASO.GetHashCode() : 0)
               ^ (NR_34 != null ? NR_34.GetHashCode() : 0)
               ^ (NR_10 != null ? NR_10.GetHashCode() : 0)
               ^ (NR_33 != null ? NR_33.GetHashCode() : 0)
               ^ (NR_35 != null ? NR_35.GetHashCode() : 0)
               ^ (Estado != null ? Estado.GetHashCode() : 0)
               ^ (User != null ? User.GetHashCode() : 0)
               ^ (Motivo != null ? Motivo.GetHashCode() : 0)
               ^ (Local != null ? Local.GetHashCode() : 0)
               ^ (Data != null ? Data.GetHashCode() : 0)
               ^ (Data2 != null ? Data2.GetHashCode() : 0)
               ^ (Document != null ? Document.GetHashCode() : 0);
    }
}

internal class CadastroConverter
{
    public static Cadastro Convert(string text)
    {
        var fields = text.Split(':');
        return new Cadastro(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], fields[9], fields[10], fields[11], fields[12], fields[13], fields[14], fields[15], fields[16], fields[17], fields[18], fields[19]);
    }

 
    public static string Convert(Cadastro cadastro)
    {
        return $"{cadastro.Number}:{cadastro.Name}:{cadastro.Company};{cadastro.Function};{cadastro.Identidade};{cadastro.Email};{cadastro.Vessel};{cadastro.Project};{cadastro.ASO};{cadastro.NR_34};{cadastro.NR_10};{cadastro.NR_33};{cadastro.NR_35};{cadastro.Estado};{cadastro.User};{cadastro.Motivo};{cadastro.Local};{cadastro.Data};{cadastro.Data2};{cadastro.Document}";
    }
}
}