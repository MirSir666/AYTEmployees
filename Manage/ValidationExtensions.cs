using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage
{

    /// <summary>
    /// 验证扩展
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// 检测对象是否为null,为null则抛出<see cref="ArgumentNullException"/>异常
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="parameterName">参数名</param>
        public static void CheckNull(this object obj, string parameterName)
        {
            if (obj == null)
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty([NotNullWhen(false)] this string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty([NotNullWhen(false)] this Guid? value)
        {
            if (value == null)
                return true;
            return value == Guid.Empty;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty<T>(this IEnumerable<T>? value)
        {
            if (value == null)
                return true;
            return !value.Any();
        }

        /// <summary>
        /// 是否默认值
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="value">值</param>
        public static bool IsDefault<T>(this T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default);
        }


        /// <summary>
        /// 判断两个集合是否是相等的(所有的元素及数量都相等)
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="sourceCollection">源集合列表</param>
        /// <param name="targetCollection">目标集合列表</param>
        /// <returns>两个集合相等则返回True,否则返回False</returns>
        public static bool EqualList<T>(this IList<T> sourceCollection, IList<T> targetCollection) where T : IEquatable<T>
        {
            //空集合直接返回False,即使是两个都是空集合,也返回False
            if (sourceCollection == null || targetCollection == null)
            {
                return false;
            }

            if (object.ReferenceEquals(sourceCollection, targetCollection))
            {
                return true;
            }

            if (sourceCollection.Count != targetCollection.Count)
            {
                return false;
            }

            var sourceCollectionStaticsDict = sourceCollection.StatisticRepetition();
            var targetCollectionStaticsDict = targetCollection.StatisticRepetition();

            return sourceCollectionStaticsDict.EqualDictionary(targetCollectionStaticsDict);
        }

        private static Dictionary<T, int> StatisticRepetition<T>(this IEnumerable<T> sourceCollection) where T : IEquatable<T>
        {
            var collectionStaticsDict = new Dictionary<T, int>();
            foreach (var item in sourceCollection)
            {
                if (collectionStaticsDict.ContainsKey(item))
                {
                    collectionStaticsDict[item]++;
                }
                else
                {
                    collectionStaticsDict.Add(item, 1);
                }
            }

            return collectionStaticsDict;
        }


        public static bool EqualDictionary<TKey, TValue>(this Dictionary<TKey, TValue> sourceDictionary, Dictionary<TKey, TValue> targetDictionary)
    where TKey : IEquatable<TKey>
    where TValue : IEquatable<TValue>
        {
            //空字典直接返回False,即使是两个都是空字典,也返回False
            if (sourceDictionary == null || targetDictionary == null)
            {
                return false;
            }

            if (object.ReferenceEquals(sourceDictionary, targetDictionary))
            {
                return true;
            }

            if (sourceDictionary.Count != targetDictionary.Count)
            {
                return false;
            }

            //比较两个字典的Key与Value
            foreach (KeyValuePair<TKey, TValue> item in sourceDictionary)
            {
                //如果目标字典不包含源字典任意一项,则不相等
                if (!targetDictionary.ContainsKey(item.Key))
                {
                    return false;
                }

                //如果同一个字典项的值不相等,则不相等
                if (!targetDictionary[item.Key].Equals(item.Value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
