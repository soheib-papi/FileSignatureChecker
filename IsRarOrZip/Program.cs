
namespace IsRarOrZip;

class IsRarOrZip
{
    static void Main(string[] args)
    {
        //Change filePath to desired file
        string filePath = "D:\\fakezip.zip";

        try
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);

            if (IsZipFile(fileBytes))
            {
                Console.WriteLine("The file is a ZIP file.");
            }
            else if (IsRarFile(fileBytes))
            {
                Console.WriteLine("The file is a RAR file.");
            }
            else
            {
                Console.WriteLine("The file is not a ZIP or RAR file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            Console.ReadLine();
        }
    }
    
    static bool IsZipFile(byte[] fileBytes)
    {
        // ZIP file signature (first 4 bytes): 50 4B 03 04
        return fileBytes.Length >= 4 &&
               fileBytes[0] == 0x50 &&
               fileBytes[1] == 0x4B &&
               fileBytes[2] == 0x03 &&
               fileBytes[3] == 0x04;
    }

    static bool IsRarFile(byte[] fileBytes)
    {
        // RAR file signature (first 7 bytes): 52 61 72 21 1A 07 00
        return fileBytes.Length >= 7 &&
               fileBytes[0] == 0x52 &&
               fileBytes[1] == 0x61 &&
               fileBytes[2] == 0x72 &&
               fileBytes[3] == 0x21 &&
               fileBytes[4] == 0x1A &&
               fileBytes[5] == 0x07 &&
               fileBytes[6] == 0x00;
    }
}