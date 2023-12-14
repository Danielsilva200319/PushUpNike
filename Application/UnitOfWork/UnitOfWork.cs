using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NikeContext _context;
        private AddressRepository _addresses;
        private CategoryRepository _categories;
        private CityRepository _cities;
        private ClientRepository _clients;
        private CountryRepository _countries;
        private DepartmentRepository _departments;
        private DiscountRepository _discounts;
        private EmployeeRepository _employees;
        private OrderRepository _orders;
        private PaymentRepository _payments;
        private PhoneRepository _phones;
        private PostalCodeRepository _postalcodes;
        private ProductRepostory _products;
        private ShipmentRepository _shipments;
        private StatusRepository _status;
        private TypeClientRepository _typeclients;
        private TypeOrderRepository _typeorders;
        private TypePaymentRepository _typepayments;
        private TypeProductRepository _typeproducts;
        private TypeShipmentRepository _typeshipments;
        private RolRepository _rols;
        private UserRepository _users;
        private RefreshTokenRepository _refreshtoken;

        public UnitOfWork(NikeContext context)
        {
            _context = context;
        }

        public IAddress Addresses
        {
            get
            {
                if (_addresses == null)
                {
                    _addresses = new AddressRepository(_context);
                }
                return _addresses;
            }
        }

        public ICategory Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(_context);
                }
                return _categories;
            }
        }

        public ICity Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new CityRepository(_context);
                }
                return _cities;
            }
        }

        public IClient Clients
        {
            get
            {
                if (_clients == null)
                {
                    _clients = new ClientRepository(_context);
                }
                return _clients;
            }
        }

        public ICountry Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new CountryRepository(_context);
                }
                return _countries;;
            }
        }

        public IDepartment Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = new DepartmentRepository(_context);
                }
                return _departments;
            }
        }

        public IDiscount Discounts
        {
            get
            {
                if (_discounts == null)
                {
                    _discounts = new DiscountRepository(_context);
                }
                return _discounts;
            }
        }

        public IEmployee Employees
        {
            get
            {
                if (_employees == null)
                {
                    _employees = new EmployeeRepository(_context);
                }
                return _employees;
            }
        }

        public IOrder Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new OrderRepository(_context);
                }
                return _orders;
            }
        }

        public IPayment Payments
        {
            get
            {
                if (_payments == null)
                {
                    _payments = new PaymentRepository(_context);
                }
                return _payments;
            }
        }

        public IPhone Phones
        {
            get
            {
                if (_phones == null)
                {
                    _phones = new PhoneRepository(_context);
                }
                return _phones;
            }
        }

        public IPostalCode PostalCodes
        {
            get
            {
                if (_postalcodes == null)
                {
                    _postalcodes = new PostalCodeRepository(_context);
                }
                return _postalcodes;
            }
        }

        public IProduct Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepostory(_context);
                }
                return _products;
            }
        }

        public IShipment Shipments
        {
            get
            {
                if (_shipments == null)
                {
                    _shipments = new ShipmentRepository(_context);
                }
                return _shipments;
            }
        }

        public IStatus Status
        {
            get
            {
                if (_status == null)
                {
                    _status = new StatusRepository(_context);
                }
                return _status;
            }
        }

        public ITypeClient TypeClients
        {
            get
            {
                if (_typeclients == null)
                {
                    _typeclients = new TypeClientRepository(_context);
                }
                return _typeclients;
            }
        }

        public ITypeOrder TypeOrders
        {
            get
            {
                if (_typeorders == null)
                {
                    _typeorders = new TypeOrderRepository(_context);
                }
                return _typeorders;
            }
        }

        public ITypePayment TypePayments
        {
            get
            {
                if (_typepayments == null)
                {
                    _typepayments = new TypePaymentRepository(_context);
                }
                return _typepayments;
            }
        }

        public ITypeProduct TypeProducts
        {
            get
            {
                if (_typeproducts == null)
                {
                    _typeproducts = new TypeProductRepository(_context);
                }
                return _typeproducts;
            }
        }

        public ITypeShipment TypeShipments
        {
            get
            {
                if (_typeshipments == null)
                {
                    _typeshipments = new TypeShipmentRepository(_context);
                }
                return _typeshipments;
            }
        }

        public IRol Rols
        {
            get
            {
                if (_rols == null)
                {
                    _rols = new RolRepository(_context);
                }
                return _rols;
            }
        }

        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public IRefreshToken RefreshToken
        {
            get
            {
                if (_refreshtoken == null)
                {
                    _refreshtoken = new RefreshTokenRepository(_context);
                }
                return _refreshtoken;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}