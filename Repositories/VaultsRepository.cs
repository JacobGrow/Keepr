using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {

    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

  
    internal IEnumerable<Vault> GetVaultsByUserId(string userId)
    {
       string sql = "SELECT * FROM vaults WHERE userId = @UserId";
      return _db.Query<Vault>(sql, new { userId });
    }


    internal Vault GetById(int vaultId)
    {
      string sql = "SELECT * FROM vaults WHERE id = @vaultId";
      return _db.QueryFirstOrDefault<Vault>(sql, new { vaultId });
    }
    internal IEnumerable<Vault> GetAll()
    {
      string sql = "SELECT * FROM vaults";
      return _db.Query<Vault>(sql);
    }

    internal Vault Create(Vault newVault)
    {
     string sql = @"
     INSERT INTO vaults
     (userId, name, description)
     VALUES
     (@UserId, @Name, @Description);
     SELECT LAST_INSERT_ID()";
     newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
     return newVault;
    }

    internal Vault Edit(Vault original)
    {
      string sql = @"
      UPDATE vaults
      SET
        name = @Name,
        description = @Description
      WHERE id = @Id;";
     return _db.QueryFirstOrDefault<Vault>(sql, original);
    }

    internal bool Delete(int id, string userId)
    {
     string sql = "DELETE FROM vaults WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
    }
  }
}