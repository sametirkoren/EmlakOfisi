using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataTransferObjects;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AdvertManager : IAdvertService
    {
        private IAdvertDal _advertDal;

        public AdvertManager(IAdvertDal advertDal)
        {
            _advertDal = advertDal;
        }

        public IDataResult<Advert> GetById(int advertId)
        {
            return new SuccessDataResult<Advert>(_advertDal.Get(a => a.Id == advertId)); 
        }


        public IDataResult<List<Advert>> GetByRealEstate(int realEstateId)
        {
            return new SuccessDataResult<List<Advert>>(_advertDal.GetList(a => a.RealEstateId == realEstateId).ToList());
        }

        public IResult Add(Advert advert)
        {
            _advertDal.Add(advert);
            return new SuccessResult(Messages.AdvertAdded);
        }

        public IResult Delete(Advert advert)
        {
            _advertDal.Delete(advert);
            return new SuccessResult(Messages.AdvertDeleted);
        }

        public IResult Update(Advert advert)
        {
            _advertDal.Update(advert);
            return new SuccessResult(Messages.AdvertUpdated);
        }

        public List<AdvertForListDto> GetList()
        {
            var result = _advertDal.MapToAdvertForList();
            var dto = MapToAdvertForListDto(result);
            return (dto);
        }

        private List<AdvertForListDto> MapToAdvertForListDto(List<Advert> advert)
        {
            var returnedDto = new List<AdvertForListDto>(advert.Select(a => new AdvertForListDto
            {
                Id = a.Id,
                RoomCount = a.RoomCount,
                BuildAge = a.BuildAge,
                BuildFloor = a.BuildFloor,
                Floor = a.Floor,
                SquareMeter = a.SquareMeter,
                ListingDate = a.ListingDate,
                Description = a.Description,
                Title = a.Title,
                Address = a.Address,
                IsLive = a.IsLive,
                Price = a.Price,
                
                
                Province = new ProvinceDto
                {
                    Name = a.Province.Name
                },
                District = new DistrictDto
                {
                  
                    Name = a.District.Name
                },

                Place = new PlaceDto
                {
                    Name = a.Place.Name
                },
                Neighborhood = new NeighborhoodDto
                {
                   
                    Name = a.Neighborhood.Name,
                    PostCode = a.Neighborhood.PostCode
                    
                },
                RealEstate = new RealEstateDto
                {
                   
                    CompanyName = a.RealEstate.CompanyName,
                    UserName = a.RealEstate.UserName,
                    Address = a.RealEstate.Address,
                    Mail = a.RealEstate.Mail
                    
                },
                AdvertType = new AdvertTypeDto
                {
                    Name = a.AdvertType.Name
                },
                Heating = new HeatingDto
                {
                    Name = a.Heating.Name
                },
                Photos = a.Photos.Select(ap => new PhotoDto
                {
                    FileName = ap.FileName,
                    IsMain = ap.IsMain
                }).ToList()
            }));

            return returnedDto;
        }
    }
}
