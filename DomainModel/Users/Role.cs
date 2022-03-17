using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Users
{
    public enum Role
    {
        Viewer, // 閲覧のみ
        Editor, // 上記に加え、チャンネルと動画の追加、変更ができる
        Maintainer, // 上記に加え、チャンネルと動画の削除ができる
        Administrator // 上記に加え、ユーザの削除ができる
    }
}
