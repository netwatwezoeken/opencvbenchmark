using OpenCvSharp;

namespace opencvBenchmark
{
    public class CSharpMatcher
    {
        public static (double, double, Point) Match(string imagefile, string templatefile)
        {
            var image = Cv2.ImRead(imagefile);
            var templateImage = Cv2.ImRead(templatefile);
            var matchedImage = new Mat();
            Cv2.MatchTemplate(templateImage, image, matchedImage, TemplateMatchModes.CCorrNormed);
            Cv2.MinMaxLoc(matchedImage, out double min, out double max, out Point minLoc, out Point maxLoc);
            return (min, max, maxLoc);
        }

        public static void ShowMatch(string imagefile, string templatefile)
        {
            var result = Match(imagefile, templatefile);
            var image = Cv2.ImRead(imagefile);
            var templateImage = Cv2.ImRead(templatefile);
            Rect r = new Rect(new Point(result.Item3.X, result.Item3.Y), new Size(templateImage.Width, templateImage.Height));
            Cv2.Rectangle(image, r, Scalar.Red, 2);
            Cv2.ImShow("Matches", image);
            Cv2.WaitKey();
        }
    }
}
