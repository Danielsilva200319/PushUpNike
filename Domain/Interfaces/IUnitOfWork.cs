using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAddress Addresses { get; }
        ICategory Categories { get; }
        ICity Cities { get; }
        IClient Clients { get; }
        ICountry Countries { get; }
        IDepartment Departments { get; }
        IDiscount Discounts { get; }
        IEmployee Employees { get; }
        IOrder Orders { get; }
        IPayment Payments { get; }
        IPhone Phones { get; }
        IPostalCode PostalCodes { get; }
        IProduct Products { get; }
        IShipment Shipments { get; }
        IStatus Status { get; }
        ITypeClient TypeClients { get; }
        ITypeOrder TypeOrders { get; }
        ITypePayment TypePayments { get; }
        ITypeProduct TypeProducts { get; }
        ITypeShipment TypeShipments { get; }
        IRol Rols { get; }
        IUser Users { get; }
        IRefreshToken RefreshToken { get; }
        Task<int> SaveAsync();
    }
}