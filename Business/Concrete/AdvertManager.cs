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

        public List<AdvertForListDto> GetList(int realEstateId)
        {
            var result = _advertDal.MapToAdvertForList();
            var dto = MapToAdvertForListDto(result, realEstateId);
            return (dto);
        }

        public List<Advert> GetAll()
        {
            return _advertDal.GetList();
        }

        private List<AdvertForListDto> MapToAdvertForListDto(List<Advert> advert, int realEstateId)
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
                RealEstateId = a.RealEstateId,
                
                
                
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
                    Id = a.RealEstate.Id,
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
                    Id = ap.Id,
                    AdvertId =  a.Id,
                    FileName = ap.FileName,
                    IsMain = ap.IsMain
                }).ToList()
            }));
            returnedDto = returnedDto.Where(x => x.RealEstateId == realEstateId).ToList();
            return returnedDto;
        }


        private AdvertForListDto MapToAdvertDto(Advert advert , int advertId)
        {
            var returnedDto = new AdvertForListDto
            {
                Id = advertId,
                RoomCount = advert.RoomCount,
                BuildAge = advert.BuildAge,
                BuildFloor = advert.BuildFloor,
                Floor = advert.Floor,
                SquareMeter = advert.SquareMeter,
                ListingDate = advert.ListingDate,
                Description = advert.Description,
                Title = advert.Title,
                Address = advert.Address,
                IsLive = advert.IsLive,
                Price = advert.Price,
                RealEstateId = advert.RealEstateId,
                ProvinceId = advert.ProvinceId,
                PlaceId = advert.PlaceId,
                DistrictId = advert.DistrictId,
                NeighborhoodId = advert.NeighborhoodId,
                AdvertTypeId = advert.AdvertTypeId,
                HeatingId = advert.HeatingId,


                Province = new ProvinceDto
                {
                    Name = advert.Province.Name
                },
                District = new DistrictDto
                {

                    Name = advert.District.Name
                },

                Place = new PlaceDto
                {
                    Name = advert.Place.Name

                },
                Neighborhood = new NeighborhoodDto
                {

                    Name = advert.Neighborhood.Name,
                    PostCode = advert.Neighborhood.PostCode

                },
                RealEstate = new RealEstateDto
                {
                    Id = advert.RealEstate.Id,
                    CompanyName = advert.RealEstate.CompanyName,
                    UserName = advert.RealEstate.UserName,
                    Address = advert.RealEstate.Address,
                    Mail = advert.RealEstate.Mail

                },
                AdvertType = new AdvertTypeDto
                {
                    Name = advert.AdvertType.Name
                },
                Heating = new HeatingDto
                {
                    Name = advert.Heating.Name
                },
                Photos = advert.Photos.Select(ap => new PhotoDto
                {
                    Id = ap.Id,
                    AdvertId = advert.Id,
                    FileName = ap.FileName,
                    IsMain = ap.IsMain
                }).ToList()
            };
            return returnedDto;
        }

        public AdvertForListDto Get(int advertId)
        {
            var result = _advertDal.MapToAdvert(advertId);
            var dto = MapToAdvertDto(result, advertId);
            return (dto);
        }

        public Advert GetByPhoto(int advertId)
        {
           var  result = _advertDal.AdvertToPhoto(advertId);
           return result;
        }
    }
}
