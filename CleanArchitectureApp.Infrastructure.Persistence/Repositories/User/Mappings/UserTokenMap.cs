using CleanArchitectureApp.Domain;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace CleanArchitectureApp.Infrastructure.Persistence.Repositories
{
    public partial class UserTokenMap : ClassMapping<UserToken>
    {
        public UserTokenMap()
        {
            Table("UserTokens");
            Lazy(true);
            Id(x => x.UserTokenId, map => map.Generator(Generators.Guid));
            Property(x => x.Token, map => map.NotNullable(true));
            Property(x => x.JwtToken, map => map.NotNullable(true));
            Property(x => x.Expires, map =>
            {
                map.NotNullable(true);
                map.Column("ExpireDate");
            });
            Property(x => x.ReplacedByToken);
            Property(x => x.CreatedDate, map => map.NotNullable(true));
            Property(x => x.RevokedDate);
            Property(x => x.CreatedByIp, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.RevokedByIp, map => map.Length(50));
            Property(x => x.UserId, map => {map.NotNullable(true); map.Type(NHibernateUtil.Guid);});
           /* ManyToOne(x => x.Users, map =>
            {
                map.Column("UserId");
                map.PropertyRef("UserId");
                map.NotNullable(true);
                map.Cascade(Cascade.All);
                map.Fetch(FetchKind.Select);
            }); */
        }
    }
}