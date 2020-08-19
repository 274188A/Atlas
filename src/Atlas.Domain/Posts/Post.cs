﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Atlas.Domain.Forums;
using Atlas.Domain.Members;

namespace Atlas.Domain.Posts
{
    public class Post
    {
        public Guid Id { get; private set; }
        public Guid ForumId { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string Content { get; private set; }
        public int RepliesCount { get; private set; }
        public StatusType Status { get; private set; }

        [Column("CreatedBy")]
        [ForeignKey("CreatedByMember")]
        public Guid MemberId { get; private set; }

        [Column("CreatedOn")]
        public DateTime TimeStamp { get; private set; }

        [ForeignKey("ModifiedByMember")]
        public Guid? ModifiedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }

        public bool Pinned { get; private set; }
        public bool Locked { get; private set; }
        public bool IsAnswer { get; private set; }
        public bool HasAnswer { get; private set; }

        [ForeignKey("Topic")]
        public Guid? TopicId { get; private set; }

        [ForeignKey("LastReply")]
        public Guid? LastReplyId { get; private set; }

        public virtual Post Topic { get; set; }
        public virtual Post LastReply { get; set; }
        public virtual Forum Forum { get; set; }
        public virtual Member CreatedByMember { get; set; }
        public virtual Member ModifiedByMember { get; set; }
        
        public Post()
        {

        }

        public static Post CreateTopic(Guid forumId, Guid memberId, string title, string slug, string content, StatusType status)
        {
            return new Post(Guid.NewGuid(), null, forumId, memberId, title, slug, content, status);
        }

        public static Post CreateTopic(Guid id, Guid forumId, Guid memberId, string title, string slug, string content, StatusType status)
        {
            return new Post(id, null, forumId, memberId, title, slug, content, status);
        }

        public static Post CreateReply(Guid topicId, Guid forumId, Guid memberId, string content, StatusType status)
        {
            return new Post(Guid.NewGuid(), topicId, forumId, memberId, null, null, content, status);
        }

        public static Post CreateReply(Guid id, Guid topicId, Guid forumId, Guid memberId, string content, StatusType status)
        {
            return new Post(id, topicId, forumId, memberId, null, null, content, status);
        }

        private Post(Guid id, Guid? topicId, Guid forumId, Guid memberId, string title, string slug, string content, StatusType status)
        {
            Id = id;
            TopicId = topicId;
            ForumId = forumId;
            MemberId = memberId;
            Title = title;
            Slug = slug;
            Content = content;
            Status = status;
            TimeStamp = DateTime.UtcNow;
        }

        public void UpdateDetails(Guid memberId, string title, string slug, string content, StatusType status)
        {
            ModifiedBy = memberId;
            ModifiedOn = DateTime.UtcNow;
            Title = title;
            Slug = slug;
            Content = content;
            Status = status;
        }

        public void UpdateDetails(Guid memberId, string content, StatusType status)
        {
            ModifiedBy = memberId;
            ModifiedOn = DateTime.UtcNow;
            Content = content;
            Status = status;
        }

        public void UpdateLastReply(Guid lastReplyId)
        {
            if (IsTopic())
            {
                LastReplyId = lastReplyId;
            }
        }

        public void IncreaseRepliesCount()
        {
            RepliesCount += 1;
        }

        public void DecreaseRepliesCount()
        {
            RepliesCount -= 1;

            if (RepliesCount < 0)
            {
                RepliesCount = 0;
            }
        }

        public void Pin(bool pinned)
        {
            if (IsTopic())
            {
                Pinned = pinned;
            }
        }

        public void Lock(bool locked)
        {
            if (IsTopic())
            {
                Locked = locked;
            }
        }

        public void SetAsAnswer(bool isAnswer)
        {
            if (!IsTopic())
            {
                IsAnswer = isAnswer;
            }
        }

        public void SetAsAnswered(bool hasAnswer)
        {
            if (IsTopic())
            {
                HasAnswer = hasAnswer;
            }
        }

        public void Delete()
        {
            Status = StatusType.Deleted;
        }

        public bool IsTopic()
        {
            return TopicId == null;
        }
    }
}