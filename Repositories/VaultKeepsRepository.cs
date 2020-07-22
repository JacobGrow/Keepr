using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }
    internal DTOVaultKeep GetById(int Id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<DTOVaultKeep>(sql, new { Id });
    }

    internal int Create(DTOVaultKeep newDTOVaultKeep)
    {
       string sql = @"
        INSERT INTO vaultkeeps
        (vaultId, keepId, userId)
        VALUES
        (@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newDTOVaultKeep);
    }

    internal void Delete(int Id)
    {
       string sql = "DELETE FROM vaultkeeps WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal IEnumerable<VaultKeep> GetKeepsByVaultId(int id)
    {
        string sql = @"
        SELECT 
            k.*
            vk.id as vaultKeepId
        FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId
        WHERE(vk.vaultId = @id)";
        return _db.Query<VaultKeep>(sql, new { id });
    }
  }
}

// CREATE TABLE tacoingredients(
//   id int NOT NULL AUTO_INCREMENT,
//   tacoId int NOT NULL,
//   ingId int NOT NULL,
//   PRIMARY KEY(id),
//   FOREIGN KEY (tacoId)
//     REFERENCES tacos (id)
//     ON DELETE CASCADE,
//   FOREIGN KEY (ingId)
//     REFERENCES ingredients (id)
//     ON DELETE CASCADE
// )