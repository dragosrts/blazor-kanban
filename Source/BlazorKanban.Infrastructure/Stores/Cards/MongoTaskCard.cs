﻿using BlazorKanban.Infrastructure.Common;
using MongoDB.Bson;

namespace BlazorKanban.Infrastructure.Stores.Cards
{
    public class MongoTaskCard : MongoStoreBaseEntity
    {
        // reference to MongoList
        public ObjectId ListId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}