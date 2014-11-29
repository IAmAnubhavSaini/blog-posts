#include <stdio.h>

struct BinarySearchObject{
	int left, right, toFind;
	int *numbers;
	int rangeStart, rangeEnd;
};
typedef struct BinarySearchObject BSO;

void getBinarySearchRangeBSO(BSO *bso);
BSO *getBSO(int left, int right, int Array[], int toFind);
int binarySearch(int left, int right, int Array[], int toFind);
int binarySearchBSO(BSO *bso);

int main(void) {
	int leftIndex, rightIndex;
	int numbers[] = { 1, 1, 3, 4, 4, 4, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 19, 20 };
	BSO *bso = getBSO(0, 19, numbers, 4);
	getBinarySearchRangeBSO(bso);
	printf("\nRange : %d - %d\n", bso->rangeStart, bso->rangeEnd);
	return 0;
}

BSO *getBSO(int left, int right, int Array[], int toFind) {
	BSO * bso = (BSO*)malloc(sizeof(BSO));
	if (bso == NULL){
		return NULL;
	}
	bso->left = left;
	bso->right = right;
	bso->numbers = Array;
	bso->toFind = toFind;
	return bso;
}

void getBinarySearchRangeBSO(BSO *bso) {
	BSO *leftBSO = NULL;
	BSO *rightBSO = NULL;
	int left = bso->left;
	int right = bso->right;
	int toFind = bso->toFind;
	int *Array = bso->numbers;
	int mostLeft;
	int mostRight;
	int foundIndex = binarySearchBSO(bso);
	mostLeft = -1;
	mostRight = -1;

	if (foundIndex >= 0){
		if (foundIndex - 1 >= 0 && Array[foundIndex - 1] == toFind){
			if ((leftBSO = getBSO(left, foundIndex - 1, Array, toFind)) == NULL){
				return;
			}
			mostLeft = binarySearchBSO(leftBSO);
		}
		if (mostLeft == -1){
			mostLeft = foundIndex;
		}
		if (foundIndex + 1 <= right && Array[foundIndex + 1] == toFind){
			if ((rightBSO = getBSO(foundIndex + 1, right, Array, toFind)) == NULL){
				return;
			}
			mostRight = binarySearchBSO(rightBSO);
		}
		if (mostRight == -1){
			mostRight = foundIndex;
		}
	}
	bso->rangeStart = mostLeft;
	bso->rangeEnd = mostRight;
}

int binarySearchBSO(BSO *bso) {
	int mid =-1;
	while (bso->left <= bso->right){
		mid = bso->left + (bso->right - bso->left) / 2;
		if (bso->numbers[mid] == bso->toFind){
			return mid;
		}
		else if (bso->numbers[mid] > bso->toFind) {
			bso->right = mid - 1;
		}
		else {
			bso->left = mid + 1;
		}
	}
	return -1;
}

int binarySearch(int left, int right, int Array[], int toFind) {
	int mid = -1;
	while (left <= right){
		mid = left + (right - left) / 2;
		if (Array[mid] == toFind){
			return mid;
		}
		else if (Array[mid] > toFind) {
			right = mid - 1;
		}
		else {
			left = mid + 1;
		}
	}
	return -1;
}