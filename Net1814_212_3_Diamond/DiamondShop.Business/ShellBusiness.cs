using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.Business.Base;
using DiamondShop.Common;
using DiamondShop.Data.Models;
using DiamondShop.Data;

namespace DiamondShop.Business
{
	public interface IShellBusiness
	{
		Task<IBusinessResult> GetAll();
		Task<IBusinessResult> GetById(string code);
		Task<IBusinessResult> Save(Shell Shell);
		Task<IBusinessResult> Update(Shell Shell);
		Task<IBusinessResult> DeleteById(string code);
	}
	public class ShellBusiness : IShellBusiness
	{
		//private readonly ShellDAO _DAO;        
		//private readonly ShellRepository _ShellRepository;
		private readonly UnitOfWork _unitOfWork;

		public ShellBusiness()
		{
			//_ShellRepository ??= new ShellRepository();            
			_unitOfWork ??= new UnitOfWork();
		}

		public async Task<IBusinessResult> GetAll()
		{
			try
			{
				#region Business rule
				#endregion

				//var currencies = _DAO.GetAll();
				//var currencies = await _ShellRepository.GetAllAsync();
				var shell = await _unitOfWork.ShellRepository.GetAllAsync();


				if (shell == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
				}
				else
				{
					return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, shell);
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

				//var Shell = await _ShellRepository.GetByIdAsync(code);
				var Shell = await _unitOfWork.ShellRepository.GetByIdAsync(code);

				if (Shell == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
				}
				else
				{
					return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, Shell);
				}
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public async Task<IBusinessResult> Save(Shell Shell)
		{
			try
			{
				//int result = await _ShellRepository.CreateAsync(Shell);
				int result = await _unitOfWork.ShellRepository.CreateAsync(Shell);
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

		public async Task<IBusinessResult> Update(Shell Shell)
		{
			try
			{ //int result = await _ShellRepository.UpdateAsync(Shell);
				int result = await _unitOfWork.ShellRepository.UpdateAsync(Shell);

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
				//var Shell = await _ShellRepository.GetByIdAsync(code);
				var Shell = await _unitOfWork.ShellRepository.GetByIdAsync(code);
				if (Shell != null)
				{
					//var result = await _ShellRepository.RemoveAsync(Shell);
					var result = await _unitOfWork.ShellRepository.RemoveAsync(Shell);
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
			Shell shell)
		{
			try
			{

				//var ProductCategory = await _ProductCategoryRepository.GetByIdAsync(code);
				var result = await _unitOfWork.ShellRepository.SearchByFieldsAsync(shell);

				if (result == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
				}
				else
				{
					return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, result);
				}
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}
	}
	}
