using Microsoft.AspNetCore.Mvc.ModelBinding;
using PracticeModul.Models;

namespace PracticeModul.Helpers
{
    public class HeroModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            string id = bindingContext.ValueProvider.GetValue("id").FirstValue;
            Hero hero = new Hero(id);
            hero.Name = bindingContext.ValueProvider.GetValue("name").FirstValue;
            hero.Level = int.Parse(bindingContext.ValueProvider.GetValue("level").FirstValue);
            hero.Kast = (ClassEnum)int.Parse(bindingContext.ValueProvider.GetValue("kast").FirstValue);
            hero.HasMount= bool.Parse(bindingContext.ValueProvider.GetValue("hasmount").FirstValue);

            if (bindingContext.HttpContext.Request.Form.Files.Count > 0)
            {
                var file = bindingContext.HttpContext.Request.Form.Files[0];
                using (var stream = file.OpenReadStream())
                {
                    byte[] buffer = new byte[file.Length];
                    stream.Read(buffer, 0, (int)file.Length);
                    hero.Data = buffer;
                    hero.ContentType = file.ContentType;
                }
            }

            bindingContext.Result = ModelBindingResult.Success(hero);
            return Task.CompletedTask;
        }
    }
}
