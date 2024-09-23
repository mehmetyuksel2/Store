using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        [HtmlAttributeName("user-name")]
        public string? UserName { get; set; }

        public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                output.Content.SetContent("Kullanıcı Bulunamadı");
                return;
            }

            TagBuilder ul = new TagBuilder("ul");
            var roles = await _roleManager.Roles.ToListAsync();

            foreach (var role in roles)
            {
                TagBuilder li = new TagBuilder("li");
                bool isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                li.InnerHtml.Append($"{role.Name}: {isInRole}");
                ul.InnerHtml.AppendHtml(li);
            }

            output.Content.AppendHtml(ul);
        }
    }
}
