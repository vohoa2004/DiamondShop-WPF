﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.Data.Repository;
using DiamondShop.Data.Models;
using DiamondShop.Data.Repository;

namespace DiamondShop.Data
{
    public class UnitOfWork
    {
        private DiamondRepository _diamond;

        private CategoryRepository _category;

        private CustomerRepository _customer;

        private ShellRepository _shell;

        private OrderRepository _order;

        private PromotionRepository _promotion;


        private OrderDetailRepository _orderDetail;



        private Net1814_212_3_DiamondContext _unitOfWorkContext;
        public UnitOfWork()
        {
            _unitOfWorkContext ??= new Net1814_212_3_DiamondContext();
        }

        public DiamondRepository DiamondRepository
        {
            get
            {
                return _diamond ??= new Repository.DiamondRepository(_unitOfWorkContext);
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                return _category ??= new Repository.CategoryRepository(_unitOfWorkContext);
            }
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                return _customer ??= new Repository.CustomerRepository(_unitOfWorkContext);
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                return _order ??= new OrderRepository(_unitOfWorkContext);
            }
        }

        public OrderDetailRepository OrderDetailRepository
        {
            get
            {
                return _orderDetail ??= new Repository.OrderDetailRepository(_unitOfWorkContext);
            }
        }

        public ShellRepository ShellRepository
        {
            get
            {
                return _shell ??= new Repository.ShellRepository(_unitOfWorkContext);
            }
        }

        public PromotionRepository promotionRepository
        {
            get
            {
                return _promotion ??= new PromotionRepository(_unitOfWorkContext);
            }
        }

        ////TO-DO CODE HERE/////////////////

        #region Set transaction isolation levels

        /*
        Read Uncommitted: The lowest level of isolation, allows transactions to read uncommitted data from other transactions. This can lead to dirty reads and other issues.

        Read Committed: Transactions can only read data that has been committed by other transactions. This level avoids dirty reads but can still experience other isolation problems.

        Repeatable Read: Transactions can only read data that was committed before their execution, and all reads are repeatable. This prevents dirty reads and non-repeatable reads, but may still experience phantom reads.

        Serializable: The highest level of isolation, ensuring that transactions are completely isolated from one another. This can lead to increased lock contention, potentially hurting performance.

        Snapshot: This isolation level uses row versioning to avoid locks, providing consistency without impeding concurrency. 
         */

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    result = _unitOfWorkContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _unitOfWorkContext.Database.BeginTransaction())
            {
                try
                {
                    result = await _unitOfWorkContext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        #endregion
    }
}
