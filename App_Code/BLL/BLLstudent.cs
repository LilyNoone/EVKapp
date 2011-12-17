using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for BLLstudent
/// </summary>
public class BLLstudent
{
    DALstudent DALstudent = new DALstudent();

    public void insertStudent(Student s)
    {
        DALstudent.insertStudent(s);
    }
    public int insertExternvak(ExternVak ev)
    {
        return DALstudent.insertExternvak(ev);
    }

    public string getMD5Hash(string passwd)
    {
        MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
        byte[] bs = Encoding.UTF8.GetBytes(passwd);
        bs = x.ComputeHash(bs);
        StringBuilder str = new StringBuilder();
        foreach (byte b in bs)
        {
            str.Append(b.ToString("x2").ToLower());
        }
        string password = str.ToString();
        return password;
    }
    public void insertFile(Bijlage s)
    {
        string p = s.bijlageURL;
            if (p.EndsWith(".doc", StringComparison.Ordinal) || p.EndsWith(".pdf", StringComparison.Ordinal) || p.EndsWith(".docx", StringComparison.Ordinal))
            {
                DALstudent.insertFile(s);
            }
            else
            {
                throw new Exception("Dit is geen geldig bestand, gelieve een Word Document of een pdf te uploaden.");
            }
        }
    
    public List<Evk> selectVrijstellingById(int id)
    {
        return DALstudent.selectVrijstellingById(id);
    }
    public List<Bijlage> selectBijlageById(int id)
    {
        return DALstudent.selectBijlageById(id);
    }
    public void update(Bijlage bij)
    {
        DALstudent.update(bij);
    }
    public void updateEVK(Evk ek)
    {
        DALstudent.updateEVK(ek);
    }
   
}