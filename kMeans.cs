using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wella
{
    public class KMeans
    {
        public int K { get; }
        public int MaxIterations { get; }
        private List<float[]> centroids;
        List<float> tmpList = new List<float>();

        public KMeans(int k, int maxIterations)
        {
            K = k;
            MaxIterations = maxIterations;
            centroids = new List<float[]>();
        }

        public KMeans() { }

        public int[] Cluster(List<List<float>> data)
        {
            int numPoints = data[0].Count;  // Az adatok elemszáma
            int dimensions = data.Count;    // A dimenziók száma (ahány lista van)

            // Adatok átalakítása: Listák → N-dimenziós pontok
            float[][] points = new float[numPoints][];
            for (int i = 0; i < numPoints; i++)
            {
                points[i] = new float[dimensions];
                for (int j = 0; j < dimensions; j++)
                {
                    points[i][j] = data[j][i];
                }
            }

            // Középpontok inicializálása (véletlenszerűen választott pontok)
            Random rand = new Random();
            centroids = points.OrderBy(x => rand.Next()).Take(K).Select(p => (float[])p.Clone()).ToList();

            int[] labels = new int[numPoints]; // Melyik pont melyik klaszterhez tartozik
            bool changed;
            int iterations = 0;

            do
            {
                changed = false;

                // 1. Minden ponthoz megkeressük a legközelebbi klasztert
                for (int i = 0; i < numPoints; i++)
                {
                    int bestCluster = GetClosestCluster(points[i]);
                    if (labels[i] != bestCluster)
                    {
                        labels[i] = bestCluster;
                        changed = true;
                    }
                }

                // 2. Klaszterközéppontok frissítése
                UpdateCentroids(points, labels);

                iterations++;
            } while (changed && iterations < MaxIterations);

            return labels;
        }

        private int GetClosestCluster(float[] point)
        {
            int bestIndex = 0;
            double bestDist = double.MaxValue;

            for (int i = 0; i < K; i++)
            {
                double dist = EuclideanDistance(point, centroids[i]);
                if (dist < bestDist)
                {
                    bestDist = dist;
                    bestIndex = i;
                }
            }
            return bestIndex;
        }

        private void UpdateCentroids(float[][] points, int[] labels)
        {
            int dimensions = points[0].Length;
            float[][] newCentroids = new float[K][];
            int[] counts = new int[K];

            for (int i = 0; i < K; i++)
            {
                newCentroids[i] = new float[dimensions];
            }

            for (int i = 0; i < points.Length; i++)
            {
                int cluster = labels[i];
                counts[cluster]++;
                for (int d = 0; d < dimensions; d++)
                {
                    newCentroids[cluster][d] += points[i][d];
                }
            }

            for (int i = 0; i < K; i++)
            {
                if (counts[i] > 0)
                {
                    for (int d = 0; d < dimensions; d++)
                    {
                        newCentroids[i][d] /= counts[i]; // Átlagolás
                    }
                }
            }

            centroids = newCentroids.ToList();
        }

        private double EuclideanDistance(float[] p1, float[] p2)
        {
            double sum = 0;
            for (int i = 0; i < p1.Length; i++)
            {
                sum += Math.Pow(p1[i] - p2[i], 2);
            }
            return Math.Sqrt(sum);
        }
    }

}
