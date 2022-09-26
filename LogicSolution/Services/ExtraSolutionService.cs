using LogicSolution.Model;
using System.Net.Http;
using System.Text;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using HtmlAgilityPack;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LogicSolution.Services
{
    public class ExtraSolutionService : IExtraSolutionService
    {
        private Dictionary<METATYPE, List<string>> dictMetaTypes = new Dictionary<METATYPE, List<string>>()
        {
            { METATYPE.LINK, new List<string>(){ "URL", "OG:URL"} },
            { METATYPE.TITLE, new List<string>(){ "TITLE", "OG:TITLE"} },
            { METATYPE.DESCRIPTION, new List<string>(){ "DESCRIPTION", "OG:DESCRIPTION"} },
            { METATYPE.IMAGE, new List<string>(){ "IMAGE", "OG:IMAGE"} }
        };

        public async Task<MetaData> ExtractMetaData(string link)
        {
            try
            {
                MetaData metaData = new MetaData() { Link = link };

                using (var httpclient = new HttpClient())
                {
                    using (var response = await httpclient.GetAsync(link))
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            var buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, buffer.Length);

                            var fullHtml = Encoding.UTF8.GetString(buffer);

                            var doc = new HtmlDocument();
                            doc.LoadHtml(fullHtml);

                            var list = doc.DocumentNode.SelectNodes("//meta");
                            foreach (var node in list)
                            {
                                string name = node.GetAttributeValue("name", "");
                                name = node.GetAttributeValue("property", name);
                                string content = node.GetAttributeValue("content", "");

                                if (dictMetaTypes[METATYPE.LINK].Any(x => x.ToUpper() == name.ToUpper()))
                                {
                                    metaData.Link = content;
                                }
                                else if (dictMetaTypes[METATYPE.TITLE].Any(x => x.ToUpper() == name.ToUpper()))
                                {
                                    metaData.Title = content;
                                }
                                else if (dictMetaTypes[METATYPE.DESCRIPTION].Any(x => x.ToUpper() == name.ToUpper()))
                                {
                                    metaData.Description = content;
                                }
                                else if (dictMetaTypes[METATYPE.IMAGE].Any(x => x.ToUpper() == name.ToUpper()))
                                {
                                    metaData.Image = content;
                                }
                            }
                        }
                    }
                }
                return metaData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
