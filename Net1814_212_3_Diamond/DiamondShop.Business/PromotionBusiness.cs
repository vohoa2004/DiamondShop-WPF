using DiamondShop.Business.Base;
using DiamondShop.Common;
using DiamondShop.Data;
using DiamondShop.Data.Models;


namespace DiamondShop.Business.PromotionBusiness
{
    public interface IPromtionBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(string code);
        Task<IBusinessResult> Save(Promotion promotion);
        Task<IBusinessResult> Update(Promotion promotion);
        Task<IBusinessResult> DeleteById(string code);
    }
    public class PromotionBusiness : IPromtionBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public PromotionBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business Rule
                #endregion
                var promotion = await _unitOfWork.promotionRepository.GetAllAsync();

                if (promotion == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, promotion);
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
                #region Business Rule
                #endregion
                var order = await _unitOfWork.promotionRepository.GetByIdAsync(code);

                if (order == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, order);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IBusinessResult> Save(Promotion promotion)
        {
            try
            {
                var result = await _unitOfWork.promotionRepository.CreateAsync(promotion);
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
        public async Task<IBusinessResult> Update(Promotion promotion)
        {
            try
            {
                var result = await _unitOfWork.promotionRepository.UpdateAsync(promotion);

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
                //var currency = await _currencyRepository.GetByIdAsync(code);
                var promotion = await _unitOfWork.promotionRepository.GetByIdAsync(code);
                if (promotion != null)
                {
                    //var result = await _currencyRepository.RemoveAsync(currency);
                    var result = await _unitOfWork.promotionRepository.RemoveAsync(promotion);
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

    }
}
