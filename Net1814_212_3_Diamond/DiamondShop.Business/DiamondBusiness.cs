using DiamondShop.Business.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.Common;
using DiamondShop.Data;
using DiamondShop.Data.Models;
using DiamondShop.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.Business
{
    public interface IDiamondBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(string code);
        Task<IBusinessResult> Save(Diamond Diamond);
        Task<IBusinessResult> Update(Diamond Diamond);
        Task<IBusinessResult> DeleteById(string code);
    }
    public class DiamondBusiness : IDiamondBusiness
    {
        //private readonly DiamondDAO _DAO;        
        //private readonly DiamondRepository _DiamondRepository;
        private readonly UnitOfWork _unitOfWork;

        public DiamondBusiness()
        {
            //_DiamondRepository ??= new DiamondRepository();            
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                //var diamonds = _DAO.GetAll();
                //var diamonds = await _DiamondRepository.GetAllAsync();
                var diamonds = await _unitOfWork.DiamondRepository.GetAllAsync();


                if (diamonds == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, diamonds);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(string code)
        {
            try
            {
                #region Business rule
                #endregion

                //var Diamond = await _DiamondRepository.GetByIdAsync(code);
                var diamond = await _unitOfWork.DiamondRepository.GetByIdAsync(code);

                if (diamond == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, diamond);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(Diamond Diamond)
        {
            try
            {
                //int result = await _DiamondRepository.CreateAsync(Diamond);
                int result = await _unitOfWork.DiamondRepository.CreateAsync(Diamond);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(Diamond Diamond)
        {
            try
            { //int result = await _DiamondRepository.UpdateAsync(Diamond);
                int result = await _unitOfWork.DiamondRepository.UpdateAsync(Diamond);

                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.ToString());
            }
        }

        


        public async Task<IBusinessResult> DeleteById(string code)
        {
            try
            {
                //var Diamond = await _DiamondRepository.GetByIdAsync(code);
                var diamond = await _unitOfWork.DiamondRepository.GetByIdAsync(code);
                if (diamond != null)
                {
                    //var result = await _DiamondRepository.RemoveAsync(Diamond);
                    var result = await _unitOfWork.DiamondRepository.RemoveAsync(diamond);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.ToString());
            }
        }

        public async Task<IBusinessResult> SearchAsync(Diamond criteria)
        {
            try
            {
                //var searchTerm = $"{orderdetail.OrderDetailId} {orderdetail.OrderId} {orderdetail.MainDiamondId} {orderdetail.ShellId} {orderdetail.SubDiamondId}".Trim();

                var diamonds = await _unitOfWork.DiamondRepository.SearchAsync(criteria);

                if (diamonds == null || !diamonds.Any())
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, diamonds);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

    }
}
