using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows
{
    public class UploadFirebase
    {

private async Task<string> UploadFileToFirebase(string filePath)
    {
        var stream = File.Open(@filePath, FileMode.Open);

        // Create a reference to the storage bucket
        var storage = new FirebaseStorage("your_firebase_storage_bucket");

        // Create a reference to the file you want to upload
        var storageRef = storage.Child("documents").Child(Path.GetFileName(filePath));

        // Upload the file and get the download URL
        var downloadUrl = await storageRef.PutAsync(stream);
        stream.Close();

        // Here you can get the unique ID if you need it, which could be the name of the file
        string uniqueId = Path.GetFileName(filePath);

        // Return the download URL or the unique ID
        return downloadUrl;
    }
}
}
