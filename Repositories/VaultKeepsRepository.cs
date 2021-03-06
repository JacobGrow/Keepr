using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<DTOVaultKeep> GetVaultKeepsByUser(string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE userId = @userId";
      return _db.Query<DTOVaultKeep>(sql, new{ userId });
    }
    internal DTOVaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<DTOVaultKeep>(sql, new { id });
    }

       internal IEnumerable<VaultKeepViewModel> GetAll()
       {
         string sql = "SELECT * FROM vaultkeeps";
         return _db.Query<VaultKeepViewModel>(sql);
       }


    // internal IEnumerable<VaultKeepViewModel> GetByUser()
    // {
    //   string sql = @"
    //         SELECT
    //         k.*,
    //         vk.id as vaultKeepId
    //         FROM vaultkeeps vk
    //         INNER JOIN vaults v ON v.id = vk.vaultId
    //         WHERE userId = @UserId;";

    //         return _db.Query<VaultKeepViewModel>(sql);
    // }

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

    //  internal int Create(VaultKeepViewModel newVKViewModel)
    // {
    //   string sql = @"
    //     INSERT INTO vaultkeeps
    //     (vaultId, keepId, userId)
    //     VALUES
    //     (@VaultId, @KeepId, @UserId);
    //     SELECT LAST_INSERT_ID();";
    //   return _db.ExecuteScalar<int>(sql, newVKViewModel);
    // }

    internal void Delete(int id, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id AND userId = @userId LIMIT 1";
      _db.Execute(sql, new { id, userId});
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"
           SELECT 
            k.*,
            vk.id as vaultKeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId)";
          return _db.Query<VaultKeepViewModel>(sql, new { vaultId, userId });
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