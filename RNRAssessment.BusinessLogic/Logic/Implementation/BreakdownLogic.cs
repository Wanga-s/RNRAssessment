using RNRAssessment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNRAssessment.BusinessLogic
{
    public class BreakdownLogic:IBreakdownLogic
    {
        private readonly IBreakdownRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BreakdownLogic(IBreakdownRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        #region Create
        public Breakdown InsertBreakdown(Breakdown newBreakdown)
        {
            Breakdown breakdown=_repository.Insert(newBreakdown);
            _unitOfWork.SaveChanges();
            return breakdown;
        }
        #endregion Create

        #region Read

        public bool BreakdownExists(int BreakdownId)
        {
            return _repository.Any(b=>b.Id==BreakdownId);
        }
        public IEnumerable<Breakdown> GetBreakdowns()
        {
            return _repository.Get();
        }

        public Breakdown? GetBreakdown(int BreakdownId)
        {
            return _repository.GetByID(BreakdownId);
        }
        #endregion Read

        #region Update
        public void Update(Breakdown breakdown)
        {
            _repository.Update(breakdown);
            _unitOfWork.SaveChanges(); 
        }
        #endregion Update
    }
}
