﻿using System;

namespace Atlas.Models.Public
{
    public class ForumPageModel
    {
        public ForumModel Forum { get; set; } = new ForumModel();

        public PaginatedData<TopicModel> Topics { get; set; } = new PaginatedData<TopicModel>();

        public bool CanRead { get; set; }
        public bool CanStart { get; set; }

        public class ForumModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class TopicModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public int TotalReplies { get; set; }
            public Guid MemberId { get; set; }
            public string MemberDisplayName { get; set; }
            public DateTime TimeStamp { get; set; }
            public string GravatarHash { get; set; }
            public DateTime MostRecentTimeStamp { get; set; }
            public Guid MostRecentMemberId { get; set; }
            public string MostRecentMemberDisplayName { get; set; }
        }
    }
}
