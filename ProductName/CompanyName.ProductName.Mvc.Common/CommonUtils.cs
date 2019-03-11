using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace CompanyName.ProductName.Mvc.Common
{
    public class CommonUtils
    {
        public static T ConvertType<T>(object value)
        {
            if (value == null)
            {
                return default(T);
            }

            TypeConverter destinationTypeConverter = TypeDescriptor.GetConverter(typeof(T));
            TypeConverter valueConverter = TypeDescriptor.GetConverter(value.GetType());

            if (destinationTypeConverter.CanConvertFrom(value.GetType()))
            {
                return (T)destinationTypeConverter.ConvertFrom(null, null, value);
            }

            else if (valueConverter.CanConvertTo(typeof(T)))
            {
                return (T)valueConverter.ConvertTo(null, null, value, typeof(T));
            }
            else
            {
                throw new InvalidCastException(string.Format("Cannot convert '{0}' to type '{1}'.", value, typeof(T).FullName));
            }
        }

        public static object ConvertType(object value, Type destinationType)
        {
            if (value == null)
            {
                return value;
            }

            if (destinationType == null)
            {
                throw new ArgumentNullException("Value of parameter 'destinationType' cannot be null.");
            }

            TypeConverter destinationTypeConverter = TypeDescriptor.GetConverter(destinationType);
            TypeConverter valueConverter = TypeDescriptor.GetConverter(value.GetType());

            if (destinationTypeConverter.CanConvertFrom(value.GetType()))
            {
                return destinationTypeConverter.ConvertFrom(null, null, value);
            }

            else if (valueConverter.CanConvertTo(destinationType))
            {
                return valueConverter.ConvertTo(null, null, value, destinationType);
            }
            else
            {
                throw new InvalidCastException(string.Format("Cannot convert '{0}' to type '{1}'.", value, destinationType.FullName));
            }
        }

        public static void RegisterTypeConverter<T, TC>() where TC : TypeConverter
        {
            TypeDescriptor.AddAttributes(typeof(T), new TypeConverterAttribute(typeof(TC)));
        }

        /// <summary>
        /// This function used to calculate the total pages.
        /// </summary>
        public static int CalculateTotalPages(int totalRecords, int pageSize)
        {
            int totalPages;

            if (totalRecords == 0)
            {
                return 0;
            }

            totalPages = totalRecords / pageSize;

            if (totalRecords % pageSize > 0)
            {
                totalPages++;
            }

            return totalPages;
        }

        public static byte[] GetBytesFromStream(Stream stream)
        {
            byte[] content = new Byte[(int)stream.Length];
            stream.Position = 0;
            stream.Read(content, 0, (int)stream.Length);
            return content;
        }

        /// <summary>
        /// ��ȡһ��ͼƬ���ȱ�����С��Ĵ�С��
        /// </summary>
        /// <param name="maxWidth">��Ҫ��С���Ŀ��</param>
        /// <param name="maxHeight">��Ҫ��С���ĸ߶�</param>
        /// <param name="imageOriginalWidth">ͼƬ��ԭʼ���</param>
        /// <param name="imageOriginalHeight">ͼƬ��ԭʼ�߶�</param>
        /// <returns>����ͼƬ���ȱ�����С���ʵ�ʴ�С</returns>
        public static Size GetNewSize(int maxWidth, int maxHeight, int imageOriginalWidth, int imageOriginalHeight)
        {
            double w = 0.0;
            double h = 0.0;
            double sw = Convert.ToDouble(imageOriginalWidth);
            double sh = Convert.ToDouble(imageOriginalHeight);
            double mw = Convert.ToDouble(maxWidth);
            double mh = Convert.ToDouble(maxHeight);

            if (sw < mw && sh < mh)
            {
                w = sw;
                h = sh;
            }
            else if ((sw / sh) > (mw / mh))
            {
                w = maxWidth;
                h = (w * sh) / sw;
            }
            else
            {
                h = maxHeight;
                w = (h * sw) / sh;
            }

            return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
        }

        /// <summary>
        /// �Ը�����һ��ͼƬ��Image��������һ��ָ����С������ͼ��
        /// </summary>
        /// <param name="originalImage">ԭʼͼƬ</param>
        /// <param name="thumMaxWidth">����ͼ�Ŀ��</param>
        /// <param name="thumMaxHeight">����ͼ�ĸ߶�</param>
        /// <returns>��������ͼ��Image����</returns>
        public static Image GetThumbNailImage(Image originalImage, int thumMaxWidth, int thumMaxHeight)
        {
            Size thumRealSize = Size.Empty;
            Image newImage = originalImage;
            Graphics graphics = null;

            try
            {
                thumRealSize = GetNewSize(thumMaxWidth, thumMaxHeight, originalImage.Width, originalImage.Height);
                newImage = new Bitmap(thumRealSize.Width, thumRealSize.Height);
                graphics = Graphics.FromImage(newImage);

                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                graphics.Clear(Color.Transparent);

                graphics.DrawImage(originalImage, new Rectangle(0, 0, thumRealSize.Width, thumRealSize.Height), new Rectangle(0, 0, originalImage.Width, originalImage.Height), GraphicsUnit.Pixel);
            }
            catch { }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                    graphics = null;
                }
            }

            return newImage;
        }
        /// <summary>
        /// �Ը�����һ��ͼƬ�ļ�����һ��ָ����С������ͼ��
        /// </summary>
        /// <param name="originalImage">ͼƬ�������ļ���ַ</param>
        /// <param name="thumMaxWidth">����ͼ�Ŀ��</param>
        /// <param name="thumMaxHeight">����ͼ�ĸ߶�</param>
        /// <returns>��������ͼ��Image����</returns>
        public static Image GetThumbNailImage(string imageFile, int thumMaxWidth, int thumMaxHeight)
        {
            Image originalImage = null;
            Image newImage = null;

            try
            {
                originalImage = Image.FromFile(imageFile);
                newImage = GetThumbNailImage(originalImage, thumMaxWidth, thumMaxHeight);
            }
            catch { }
            finally
            {
                if (originalImage != null)
                {
                    originalImage.Dispose();
                    originalImage = null;
                }
            }

            return newImage;
        }
        /// <summary>
        /// �Ը�����һ��ͼƬ�ļ�����һ��ָ����С������ͼ����������ͼ���浽ָ��λ�á�
        /// </summary>
        /// <param name="originalImageFile">ͼƬ�������ļ���ַ</param>
        /// <param name="thumbNailImageFile">����ͼ�������ļ���ַ</param>
        /// <param name="thumMaxWidth">����ͼ�Ŀ��</param>
        /// <param name="thumMaxHeight">����ͼ�ĸ߶�</param>
        public static void MakeThumbNail(string originalImageFile, string thumbNailImageFile, int thumMaxWidth, int thumMaxHeight)
        {
            Image newImage = GetThumbNailImage(originalImageFile, thumMaxWidth, thumMaxHeight);
            try
            {
                newImage.Save(thumbNailImageFile, ImageFormat.Jpeg);
            }
            catch
            { }
            finally
            {
                newImage.Dispose();
                newImage = null;
            }
        }
        /// <summary>
        /// ��һ��ͼƬ���ڴ�������Ϊָ����С�������ص�������ڴ�����
        /// </summary>
        /// <param name="originalImageStream">ԭʼͼƬ���ڴ���</param>
        /// <param name="newWidth">��ͼƬ�Ŀ��</param>
        /// <param name="newHeight">��ͼƬ�ĸ߶�</param>
        /// <returns>���ص������ͼƬ���ڴ���</returns>
        public static MemoryStream ResizeImage(Stream originalImageStream, int newWidth, int newHeight)
        {
            MemoryStream newImageStream = null;

            Image newImage = GetThumbNailImage(Image.FromStream(originalImageStream), newWidth, newHeight);
            if (newImage != null)
            {
                newImageStream = new MemoryStream();
                newImage.Save(newImageStream, ImageFormat.Jpeg);
            }

            return newImageStream;
        }
        /// <summary>
        /// ��һ���ڴ�������Ϊ�����ļ���
        /// </summary>
        /// <param name="stream">�ڴ���</param>
        /// <param name="newFile">Ŀ������ļ���ַ</param>
        public static void SaveStreamToFile(Stream stream, string newFile)
        {
            if (stream == null || stream.Length == 0 || string.IsNullOrEmpty(newFile))
            {
                return;
            }

            byte[] buffer = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(buffer, 0, buffer.Length);
            FileStream fileStream = new FileStream(newFile, FileMode.OpenOrCreate, FileAccess.Write);
            fileStream.Write(buffer, 0, buffer.Length);
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }
        /// <summary>
        /// ��һ��ָ����ͼƬ����ͼƬˮӡЧ����
        /// </summary>
        /// <param name="imageFile">ͼƬ�ļ���ַ</param>
        /// <param name="waterImage">ˮӡͼƬ��Image����</param>
        public static void CreateImageWaterMark(string imageFile, Image waterImage)
        {
            if (string.IsNullOrEmpty(imageFile) || !File.Exists(imageFile) || waterImage == null)
            {
                return;
            }

            Image originalImage = Image.FromFile(imageFile);

            if (originalImage.Width - 10 < waterImage.Width || originalImage.Height - 10 < waterImage.Height)
            {
                return;
            }

            Graphics graphics = Graphics.FromImage(originalImage);

            int x = originalImage.Width - waterImage.Width - 10;
            int y = originalImage.Height - waterImage.Height - 10;
            int width = waterImage.Width;
            int height = waterImage.Height;

            graphics.DrawImage(waterImage, new Rectangle(x, y, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
            graphics.Dispose();

            MemoryStream stream = new MemoryStream();
            originalImage.Save(stream, ImageFormat.Jpeg);
            originalImage.Dispose();

            Image imageWithWater = Image.FromStream(stream);

            imageWithWater.Save(imageFile);
            imageWithWater.Dispose();
        }
        /// <summary>
        /// ��һ��ָ����ͼƬ��������ˮӡЧ����
        /// </summary>
        /// <param name="imageFile">ͼƬ�ļ���ַ</param>
        /// <param name="waterText">ˮӡ��������</param>
        public static void CreateTextWaterMark(string imageFile, string waterText)
        {
            if (string.IsNullOrEmpty(imageFile) || string.IsNullOrEmpty(waterText) || !File.Exists(imageFile))
            {
                return;
            }

            Image originalImage = Image.FromFile(imageFile);

            Graphics graphics = Graphics.FromImage(originalImage);

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            SolidBrush brush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
            Font waterTextFont = new Font("Arial", 16, FontStyle.Regular);
            SizeF waterTextSize = graphics.MeasureString(waterText, waterTextFont);

            float x = (float)originalImage.Width - waterTextSize.Width - 10F;
            float y = (float)originalImage.Height - waterTextSize.Height - 10F;

            graphics.DrawString(waterText, waterTextFont, brush, x, y);

            graphics.Dispose();
            brush.Dispose();

            MemoryStream stream = new MemoryStream();
            originalImage.Save(stream, ImageFormat.Jpeg);
            originalImage.Dispose();

            Image imageWithWater = Image.FromStream(stream);

            imageWithWater.Save(imageFile);
            imageWithWater.Dispose();
        }

        public static byte[] CreateAuthCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return CreateAuthCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return CreateCodeGraphic(randomCode);
        }
        public static byte[] CreateCodeGraphic(string authCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(authCode.Length * 13.0), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //�������������
                Random random = new Random();
                //���ͼƬ����ɫ
                g.Clear(Color.White);
                //��ͼƬ�ĸ�����
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                 Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(authCode, font, brush, 3, 2);
                //��ͼƬ��ǰ�����ŵ�
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //��ͼƬ�ı߿���
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //����ͼƬ����
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //���ͼƬ��
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}
