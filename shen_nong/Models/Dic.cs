/****************************************************************
 * 
 * File name: Dic
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:40:09
 * 
 * Summary: 字典列表
 * 
 ****************************************************************/
using System.Collections.Generic;

namespace shen_nong.Models
{
    public class Dic
    {
        public List<dic_crop_type> dic_crop { get; set; }
        public List<dic_disease_type> dic_disease { get; set; }
        public List<dic_growth_type> dic_growth { get; set; }
        public List<dic_moisture_type> dic_moisture { get; set; }
        public List<dic_news_type> dic_news { get; set; }
        public List<dic_pest_type> dic_pest { get; set; }
        public List<dic_phenophase> dic_phenophase { get; set; }
        public List<dic_rsi_type> dic_rsi { get; set; }
    }
}