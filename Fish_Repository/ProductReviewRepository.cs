﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxShop_Model;
using Fish_IRepository;
namespace Fish_Repository
{
    /// <summary>
    /// 用户评价 DAL层
    /// </summary>
    public class ProductReviewRepository:BaseRepository<ProductReview>,IProductReviewRepository
    {
    }
}
