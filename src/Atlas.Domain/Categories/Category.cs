﻿using System;
using System.Collections.Generic;
using Atlas.Domain.Forums;
using Atlas.Domain.PermissionSets;
using Atlas.Domain.Sites;

namespace Atlas.Domain.Categories
{
    public class Category
    {
        public Guid Id { get; private set; }
        public Guid SiteId { get; private set; }
        public string Name { get; private set; }
        public int SortOrder { get; private set; }
        public int TopicsCount { get; private set; }
        public int RepliesCount { get; private set; }
        public StatusType Status { get; private set; }
        public Guid PermissionSetId { get; private set; }

        public virtual Site Site { get; set; }
        public virtual PermissionSet PermissionSet { get; set; }

        public virtual ICollection<Forum> Forums { get; set; }

        public Category()
        {

        }

        public Category(Guid id, Guid siteId, string name, int sortOrder, Guid permissionSetId)
        {
            New(id, siteId, name, sortOrder, permissionSetId);
        }

        public Category(Guid siteId, string name, int sortOrder, Guid permissionSetId)
        {
            New(Guid.NewGuid(), siteId, name, sortOrder, permissionSetId);
        }

        private void New(Guid id, Guid siteId, string name, int sortOrder, Guid permissionSetId)
        {
            Id = id;
            SiteId = siteId;
            Name = name;
            SortOrder = sortOrder;
            PermissionSetId = permissionSetId;
            Status = StatusType.Published;
        }

        public void UpdateDetails(string name, Guid permissionSetId)
        {
            Name = name;
            PermissionSetId = permissionSetId;
        }

        public void MoveUp()
        {
            if (SortOrder == 1)
            {
                throw new ApplicationException($"Category \"{Name}\" can't be moved up.");
            }

            SortOrder -= 1;
        }

        public void MoveDown()
        {
            SortOrder += 1;
        }

        public void Reorder(int sortOrder)
        {
            SortOrder = sortOrder;
        }

        public void IncreaseTopicsCount(int count = 1)
        {
            TopicsCount += count;
        }

        public void IncreaseRepliesCount(int count = 1)
        {
            RepliesCount += count;
        }

        public void DecreaseTopicsCount(int count = 1)
        {
            TopicsCount -= count;

            if (TopicsCount < 0)
            {
                TopicsCount = 0;
            }
        }

        public void DecreaseRepliesCount(int count = 1)
        {
            RepliesCount -= count;

            if (RepliesCount < 0)
            {
                RepliesCount = 0;
            }
        }

        public void Delete()
        {
            Status = StatusType.Deleted;
        }

        public string PermissionSetName() => PermissionSet?.Name;

        public bool HasPermissionSet() => PermissionSet != null;
    }    
}