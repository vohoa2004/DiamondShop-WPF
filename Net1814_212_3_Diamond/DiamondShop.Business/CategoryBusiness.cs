using DiamondShop.Business.Base;
using DiamondShop.Common;
using DiamondShop.Data.Models;
using DiamondShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.Business
{
    public interface ICategoryBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(string code);
        Task<IBusinessResult> Save(Productcategory Category);
        Task<IBusinessResult> Update(Productcategory Category);
        Task<IBusinessResult> DeleteById(string code);
    }
    public class CategoryBusiness : ICategoryBusiness
    {
        //private readonly CategoryDAO _DAO;        
        //private readonly CategoryRepository _CategoryRepository;
        private readonly UnitOfWork _unitOfWork;

        public CategoryBusiness()
        {
            //_CategoryRepository ??= new CategoryRepository();            
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                //var categorys = _DAO.GetAll();
                //var categorys = await _CategoryRepository.GetAllAsync();
                var categorys = await _unitOfWork.CategoryRepository.GetAllAsync();


                if (categorys == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, categorys);
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

                //var Category = await _CategoryRepository.GetByIdAsync(code);
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(code);

                if (category == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, category);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(Productcategory Category)
        {
            try
            {
                //int result = await _CategoryRepository.CreateAsync(Category);
                int result = await _unitOfWork.CategoryRepository.CreateAsync(Category);
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

        public async Task<IBusinessResult> Update(Productcategory productcategory)
        {
            try
            { //int result = await _DiamondRepository.UpdateAsync(Diamond);
                int result = await _unitOfWork.CategoryRepository.UpdateAsync(productcategory);

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
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(code);
                if (category != null)
                {
                    //var result = await _DiamondRepository.RemoveAsync(Diamond);
                    var result = await _unitOfWork.CategoryRepository.RemoveAsync(category);
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

        public async Task<IBusinessResult> SearchByFields(
            Productcategory category)
        {
            try
            {

                //var ProductCategory = await _ProductCategoryRepository.GetByIdAsync(code);
                var ProductCategory = await _unitOfWork.CategoryRepository.SearchByFieldsAsync(category);

                if (ProductCategory == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, ProductCategory);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
