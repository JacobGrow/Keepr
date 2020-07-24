using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;
using Keepr.Services;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @userId";
      return _db.Query<Keep>(sql, new { userId });
    }
    internal Keep GetById(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    internal IEnumerable<Keep> Get()
    {
    //   string sql = "SELECT * FROM keeps;";
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0";
      return _db.Query<Keep>(sql);
      //NOTE why is isPrivate breaking it?
    }



    internal Keep Create(Keep newKeep)
    {
     string sql = @"
     INSERT INTO keeps
     (userId, name, description, img, isPrivate)
     VALUES
     (@UserId, @Name, @Description, @Img, @IsPrivate);
     SELECT LAST_INSERT_ID()";
     newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
     return newKeep;
    }

    internal bool IncrementKeeps(Keep keepToUpdate)
    {
      string sql = @"
      UPDATE keeps
      SET
        keeps = @Keeps
      WHERE id = @Id;";
      // return _db.QueryFirstOrDefault<Keep>(sql, keepToUpdate);


      int affectedRows = _db.Execute(sql, keepToUpdate);
      return affectedRows == 1;
    }

            internal bool Edit(Keep keepToUpdate, string userId)
        {
            keepToUpdate.UserId = userId;
            string sql = @"
            UPDATE keeps
            SET
             description = @Description,
             name = @Name
            WHERE id = @Id
            AND userId = @UserId";
            int affectedRows = _db.Execute(sql, keepToUpdate);
            return affectedRows == 1;
        }

    internal bool Delete(int id, string userId)
    {
     string sql="DELETE FROM keeps WHERE id = @Id AND userId = @UserId LIMIT 1";
     int affectedRows = _db.Execute(sql, new { id, userId });
     return affectedRows == 1;
    }
  }
}