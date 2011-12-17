using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALstudent
/// </summary>
public class DALstudent
{
    dc_databankDataContext dc = new dc_databankDataContext();
  
    public void insertStudent(Student s)
    {
        dc.Students.InsertOnSubmit(s);
        dc.SubmitChanges();
    }
    public void insertFile(Bijlage s)
    {
        dc.Bijlages.InsertOnSubmit(s);
        dc.SubmitChanges();
    }
    public List<Evk> selectVrijstellingById(int id)
    {
        var result = (from p in dc.Evks
                      join a in dc.Vaks on p.fk_vakID equals a.pk_vakID 
                      where p.fk_studentID == id
                      select p).ToList();
        return result;
    }
    public List<Bijlage> selectBijlageById(int id)
    {
        var result = (from p in dc.Bijlages
                      where p.fk_studentID == id
                      select p);
        return result.ToList();
    }
    public int insertExternvak(ExternVak ev)
    {
        dc.ExternVaks.InsertOnSubmit(ev);
        dc.SubmitChanges();
        int id = ev.pk_externvakID;
        return id;
    }
    public void update(Bijlage bij)
    {
        var recordToUpdate = (from p in dc.Bijlages
                              where p.pk_bijlageID == bij.pk_bijlageID
                              select p).Single();

        
        recordToUpdate.fk_externvakID = bij.fk_externvakID;
        dc.SubmitChanges();
    }
    public void updateEVK(Evk ek)
    {
        var recordToUpdate = (from p in dc.Evks
                              where p.fk_studentID == ek.fk_studentID && p.fk_vakID == ek.fk_vakID
                              select p).FirstOrDefault();


        recordToUpdate.fk_externvakID = ek.fk_externvakID;
        dc.SubmitChanges();
    }
   
   
   
}