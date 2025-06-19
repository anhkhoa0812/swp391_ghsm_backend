using System.Security.Claims;

namespace Repository.Util
{
    public static class UserUtil
    {
        public static Guid GetUserId(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Guid.TryParse(userIdClaim, out Guid userId))
                return userId;

            throw new Exception("UserId không hợp lệ hoặc chưa đăng nhập.");
        }
    }
}
