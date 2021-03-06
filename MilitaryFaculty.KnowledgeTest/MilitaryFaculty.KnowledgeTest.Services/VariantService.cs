﻿using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryFaculty.KnowledgeTest.BLLInterfaces;
using MilitaryFaculty.KnowledgeTest.BLLInterfaces.Exceptions;
using MilitaryFaculty.KnowledgeTest.DALInterfaces;
using MilitaryFaculty.KnowledgeTest.Entities.Entities;
using MilitaryFaculty.KnowledgeTest.Entities.Exceptions;
using MilitaryFaculty.KnowledgeTest.Infrastructure.Guard.Validation;

namespace MilitaryFaculty.KnowledgeTest.Services
{
    public class VariantService : IVariantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _factoryOfRepositries;

        public VariantService(IUnitOfWork unitOfWork, IRepositoryFactory factoryOfRepositories)
        {
            Guard.AgainstNullReference(unitOfWork, "unitOfWork");
            Guard.AgainstNullReference(factoryOfRepositories, "factoryOfRepositories");

            _unitOfWork = unitOfWork;
            _factoryOfRepositries = factoryOfRepositories;
        }

        public Variant AddVariantToQuestion(string description, bool isRight, int questionId)
        {
            var variantRepository = _factoryOfRepositries.GetVariantRepository();

            var variant = new Variant { Description = description, IsRight = isRight, QuestionId = questionId };
            variantRepository.Add(variant);

            try
            {
                _unitOfWork.PreSave();
            }
            catch (Exception e)
            {
                throw new VariantServiceException(e);
            }

            return variant;
        }

        public void UpdateVariant(Variant variant)
        {
            var variantRepository = _factoryOfRepositries.GetVariantRepository();
            variantRepository.Update(variant);
        }

        public Variant GetVariantById(int variantId)
        {
            var variantRepository = _factoryOfRepositries.GetVariantRepository();

            try
            {
                var variant = variantRepository.GetEntityById(variantId);
                return variant;
            }
            catch (Exception ex)
            {
                throw new VariantServiceException(ex);
            }
        }

        public void RemoveVariant(Variant variant)
        {
            var variantRepository = _factoryOfRepositries.GetVariantRepository();
            variantRepository.Remove(variant);
        }

        public List<Variant> GetVariantsByQuestionId(int questionId)
        {
            var variantRepository = _factoryOfRepositries.GetVariantRepository();
            try
            {
                return variantRepository.Filter(e => e.QuestionId == questionId).ToList();
            }
            catch (Exception e)
            {
                throw new RepositoryException(e.Message);
            }
        }
    }
}
