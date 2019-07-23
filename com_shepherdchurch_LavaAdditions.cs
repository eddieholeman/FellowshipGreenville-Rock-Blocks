using System;
using DotLiquid;

using Rock;
using Rock.Data;
using Rock.Model;
using Rock.Utility;

namespace com_shepherdchurch
{
    public class LavaAdditions : IRockStartup
    {
        /// <summary>
        /// All IRockStartup classes will be run in order by this value. If class does not depend on an order, return zero.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int StartupOrder { get { return 0; } }

        /// <summary>
        /// Method that will be run at Rock startup
        /// </summary>
        public virtual void OnStartup()
        {
            Template.RegisterFilter( GetType() );
        }

        #region Group

        /// <summary>
        /// Loads a Group record from the database from it's GUID.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static Rock.Model.Group GroupByGuid( DotLiquid.Context context, object input )
        {
            if ( input == null )
            {
                return null;
            }

            Guid? groupGuid = input.ToString().AsGuidOrNull();

            if ( groupGuid.HasValue )
            {
                var rockContext = new RockContext();

                return new GroupService( rockContext ).Get( groupGuid.Value );
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Loads a Group Member record from the database from it's GUID.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static Rock.Model.GroupMember GroupMemberByGuid( DotLiquid.Context context, object input )
        {
            if ( input == null )
            {
                return null;
            }

            Guid? groupMemberGuid = input.ToString().AsGuidOrNull();

            if ( groupMemberGuid.HasValue )
            {
                var rockContext = new RockContext();

                return new GroupMemberService( rockContext ).Get( groupMemberGuid.Value );
            }
            else
            {
                return null;
            }
        }
		
        /// <summary>
        /// Loads a Group record from the database from it's Identifier.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static Rock.Model.Group GroupById( DotLiquid.Context context, object input )
        {
            if ( input == null )
            {
                return null;
            }

            int groupId = -1;

            if ( !Int32.TryParse( input.ToString(), out groupId ) )
            {
                return null;
            }

            var rockContext = new RockContext();

            return new GroupService( rockContext ).Get( groupId );
        }

        #endregion
    }
}
