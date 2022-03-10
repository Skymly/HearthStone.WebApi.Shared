using HearthStone.Models;

using Refit;
namespace HearthStone.WebApi
{
    public interface IHearthStoneApi
    {

        /// <summary>
        /// 搜索卡牌信息
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="token"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Get("/hearthstone/cards")]
        IObservable<CardSearchResult> SearchCard([AliasAs("locale")] RegionLocale locale, [AliasAs("access_token")] string token, CardSearchInput input);

        /// <summary>
        /// 获取元数据
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [Get("/hearthstone/metadata")]
        IObservable<MetaData> GetMetaDataAll([AliasAs("locale")] RegionLocale locale, [AliasAs("access_token")] string token);

        /// <summary>
        /// 搜索卡背
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="token"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Get("/hearthstone/cardbacks")]
        IObservable<CardBackSearchResult> SearchCardback([AliasAs("locale")] RegionLocale locale, [AliasAs("access_token")] string token, CardBackSearchInput input = null);

    }
}