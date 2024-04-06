using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinUIApp1;

/// <summary>
/// バインドソースクラスのベース
/// <see cref="INotifyPropertyChanged" /> の実装
/// </summary>
public class BindableBase : INotifyPropertyChanged
{
    /// <summary>
    /// 編集したか
    /// </summary>
    public bool IsEditing { get; set; }

    /// <summary>
    /// ソースに更新を通知するイベント
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// ソースに更新を通知する
    /// </summary>
    protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// 値をセットして通知
    /// </summary>
    /// <typeparam name="T">任意の型</typeparam>
    /// <param name="field">セット先のフィールド</param>
    /// <param name="value">セットしたい値</param>
    /// <param name="propertyName">通知したいプロパティ ?? 呼び出し元のプロパティ</param>
    /// <returns>セットした場合 true</returns>
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        NotifyPropertyChanged(propertyName);
        return true;
    }

    /// <summary>
    /// 値をセットして通知 (SetProperty())
    /// 編集した場合 フラグをたてる
    /// </summary>
    /// <typeparam name="T">任意の型</typeparam>
    /// <param name="field">セット先のフィールド</param>
    /// <param name="value">セットしたい値</param>
    /// <param name="propertyName">通知したいプロパティ ?? 呼び出し元のプロパティ</param>
    /// <returns>セットした場合 true</returns>
    protected bool SetEditingProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (SetProperty(ref field, value, propertyName))
        {
            if (field != null)
            {
                IsEditing = true;
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}
