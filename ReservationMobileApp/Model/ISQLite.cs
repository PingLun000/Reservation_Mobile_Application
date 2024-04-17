using System;
using SQLite;

namespace ReservationMobileApp.Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
