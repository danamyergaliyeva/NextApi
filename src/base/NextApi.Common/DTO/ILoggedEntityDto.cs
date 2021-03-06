using System;

namespace NextApi.Common.DTO
{
    /// <summary>
    /// Interface represents entity to be logged
    /// </summary>
    public interface ILoggedEntityDto
    {
        /// <summary>
        /// Contains id of user created this entity
        /// </summary>
        int? CreatedById { get; set; }

        /// <summary>
        /// Contains creation time
        /// </summary>
        DateTimeOffset? Created { get; set; }

        /// <summary>
        /// Contains id of user updated this entity last time
        /// </summary>
        int? UpdatedById { get; set; }

        /// <summary>
        /// Contains time when entity last time updated
        /// </summary>
        DateTimeOffset? Updated { get; set; }
    }
}
